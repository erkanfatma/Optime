using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using AU.Optime.Mobile.Views.Popups;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To list projects
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ProjectListPage : ContentPage {
            ProjectToUserManager p2uManager = new ProjectToUserManager();
            IEnumerable<ProjectToUserViewModel> projectList = new List<ProjectToUserViewModel>();
            public ProjectListPage() {
                  InitializeComponent();
                  listIndicator.IsRunning = true;
                  listIndicator.IsVisible = true;
                  LoadDataAsync();
            }

            private async void LoadDataAsync() {
                  projectList = await p2uManager.GetProjectsByUser(Constants.userId);

                  if(projectList.Count() < 1) {
                        emptyMessage.IsVisible = true;
                        emptyMessage.Text = "Project not found";
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  } else {
                        emptyMessage.IsVisible = false;
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  }

                  lstProjects.ItemsSource = projectList;
            }

            private void AddButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushPopupAsync(new AddProjectPopup());
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  ProjectToUserViewModel selected = (ProjectToUserViewModel)e.SelectedItem;
                  Navigation.PushAsync(new ProjectDetailPage(selected.ProjectId), false);
                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }
      }
}