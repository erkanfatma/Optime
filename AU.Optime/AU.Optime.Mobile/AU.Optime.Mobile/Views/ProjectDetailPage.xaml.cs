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
      //To show project details 
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ProjectDetailPage : ContentPage {
            ProjectManager projectManager = new ProjectManager();
            private readonly ProjectDetailViewModel project = new ProjectDetailViewModel();
            int selectedProjectId;
            public ProjectDetailPage(int projectId) {
                  InitializeComponent();
                  LoadDataAsync(projectId);
                  selectedProjectId = projectId;
            }

            private async void LoadDataAsync(int projectId) {
                  ProjectDetailViewModel project = await projectManager.Get(projectId);
                  this.BindingContext = project;
                  
            }

            private async void EditButton_Clicked(object sender, EventArgs e) {
                  await Navigation.PushPopupAsync(new EditProjectPopup(selectedProjectId), false);
            }

            private void MembersButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushAsync(new ProjectMemberListPage(selectedProjectId), false);
            }

            private void TasksButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushAsync(new ProjectTaskListPage(selectedProjectId, "project"), false);
            }

            private void BoardsButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushAsync(new ProjectBoardListPage(selectedProjectId), false);
            }

            private void DocumentsButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushAsync(new ProjectDocsListPage(selectedProjectId), false);
            }
      }
}