using AU.Optime.Mobile.Models.SelectViewModels;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using AU.Optime.Mobile.Views.Popups;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To list project members
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ProjectMemberListPage : ContentPage {
            IEnumerable<ProjectToUserViewModel> userList = new List<ProjectToUserViewModel>();
            static List<TeamMemberSelectViewModel> members = new List<TeamMemberSelectViewModel>();
            List<int> membersId = new List<int>();
            ProjectToUserManager p2uManager = new ProjectToUserManager();
            int selectedProjectId;
            public ProjectMemberListPage(int projectId) {
                  InitializeComponent();
                  listIndicator.IsRunning = true;
                  listIndicator.IsVisible = true;
                  LoadDataAsync(projectId);
                  selectedProjectId = projectId;
            }
            private async void LoadDataAsync(int projectId) {
                  userList = await p2uManager.GetUsersByProject(projectId);
                  if(userList.Count() < 1) {
                        emptyMessage.IsVisible = true;
                        emptyMessage.Text = "Members not found";
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  } else {
                        emptyMessage.IsVisible = false;
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  }
                  lstMembers.ItemsSource = userList.OrderByDescending(x => x.IsManager);
                  foreach(var item in userList) {
                        membersId.Add(item.UserId);
                        members.Add(new TeamMemberSelectViewModel {
                        Email = item.Email, 
                        FullName = item.FullName,
                        IsSelected  = true, 
                        TeamMemberId = item.UserId});
                  }
            }

            private void EditButton_Clicked(object sender, EventArgs e) {
                  if(members.Count != 0) {
                        PopupNavigation.Instance.PushAsync(new AddProjectMembersPopup(selectedProjectId,members), false);
                  } else {
                        PopupNavigation.Instance.PushAsync(new AddProjectMembersPopup(selectedProjectId), false);
                  }
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }
      }
}