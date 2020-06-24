using AU.Optime.Mobile.CustomControls;
using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.SelectViewModels;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Popups {
      //To add project members
      public partial class AddProjectMembersPopup : Rg.Plugins.Popup.Pages.PopupPage {
            UserManager userManager = new UserManager();
            ProjectToUserManager p2uManager = new ProjectToUserManager();

            List<TeamMemberSelectViewModel> selectedUsers = new List<TeamMemberSelectViewModel>();
            IEnumerable<UserViewModel> users = new List<UserViewModel>();
            public IList<TeamMemberSelectViewModel> userList { get; set; } = new ObservableCollection<TeamMemberSelectViewModel>();
            int selectedProjectId; 

            public AddProjectMembersPopup(int projectId,List<TeamMemberSelectViewModel> model = null) {
                  InitializeComponent();
                  AddItems(model);
                  selectedProjectId = projectId;
            }

          
            public List<TeamMemberSelectViewModel> FindChecked() {
                  foreach(var item in userList.Where(x => x.IsSelected)) {
                        selectedUsers.Add(new TeamMemberSelectViewModel {
                              TeamMemberId = item.TeamMemberId,
                              FullName = item.FullName,
                              Email = item.Email,
                              IsSelected = item.IsSelected
                        });
                  }
                  return selectedUsers;
            }

            private async void AddItems(List<TeamMemberSelectViewModel> model = null) {
                  users = await userManager.GetAll();
                  List<TeamMemberSelectViewModel> list = users.Select(s => new TeamMemberSelectViewModel {
                        Email = s.Email,
                        FullName = s.FullName,
                        TeamMemberId = s.UserId
                  }).ToList();
                  userList = list;
                  if(model != null) {
                        foreach(var item in userList) {
                              for(int i = 0; i < model.Count; i++) {
                                    if(model[i].TeamMemberId == item.TeamMemberId) {
                                          item.IsSelected = model[i].IsSelected;
                                    }
                              }
                        }
                  }
                  lstData.ItemsSource = userList;
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }

            private async void OnSelectClicked(object sender, EventArgs e) {
                  List<TeamMemberSelectViewModel> selectedUserList = FindChecked();
                  bool result = false;
                  foreach(var item in selectedUserList) {
                        var model = new ProjectToUserViewModel {
                              ProjectId = selectedProjectId,
                              UserId = item.TeamMemberId
                        };
                        var res = await p2uManager.PutAsync(model);
                        result = res.Result;
                  }

                  await Navigation.PopPopupAsync();
                  if(result)
                        DependencyService.Get<IMessage>().ShortAlert("Project users updated.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Project users can not be added.");
                  
                  Application.Current.MainPage = new NavigationPage(new ProjectMemberListPage(selectedProjectId));
            }

            private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e) {
                  var searchedUser = userList.Where(x => x.FullName.ToLower().Contains(userSearchBar.Text.ToLower())).ToList();
                  
                  lstData.ItemsSource = searchedUser;
            }
      }
}