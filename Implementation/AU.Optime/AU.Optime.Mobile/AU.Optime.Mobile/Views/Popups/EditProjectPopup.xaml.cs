using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Popups {
      //to edit selected project
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class EditProjectPopup : Rg.Plugins.Popup.Pages.PopupPage {
            ProjectManager projectManager = new ProjectManager();
            ProjectDetailViewModel project = new ProjectDetailViewModel();
            public EditProjectPopup(int projectId) {
                  InitializeComponent();
                  LoadDataAsync(projectId);
            }

            private async void LoadDataAsync(int projectId) {
                  project = await projectManager.Get(projectId);
                  DescriptionEditor.Text = project.Description;
                  TitleEntry.Text = project.Name;
            }

            private async void AddButton_Clicked(object sender, EventArgs e) {
                  ProjectDetailViewModel updatedProject = new ProjectDetailViewModel { Description = DescriptionEditor.Text, Name = TitleEntry.Text, ProjectId = project.ProjectId, RegisterTime = project.RegisterTime, UserId = project.UserId };
                  var result = await projectManager.PutAsync(updatedProject);
                  await Navigation.PopPopupAsync();
                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("Project updated.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Project can not be updated.");
            }

            private async void DeleteButton_Clicked(object sender, EventArgs e) {
                  ProjectViewModel deleteProject = new ProjectViewModel { ProjectId = project.ProjectId };
                  var result = await projectManager.DeleteAsync(deleteProject);
                  await Navigation.PopPopupAsync();
                  if(result)
                        DependencyService.Get<IMessage>().ShortAlert("Project deleted.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Project can not be deleted.");
            }
      }
}