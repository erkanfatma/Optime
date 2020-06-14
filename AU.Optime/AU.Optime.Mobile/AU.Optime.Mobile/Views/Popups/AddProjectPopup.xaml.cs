using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Popups {
      //To create new project
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AddProjectPopup : Rg.Plugins.Popup.Pages.PopupPage {
            ProjectManager projectManager = new ProjectManager();
            public AddProjectPopup() {
                  InitializeComponent();
            }

            private async void AddButton_Clicked(object sender, EventArgs e) {
                  ProjectDetailViewModel newProject = new ProjectDetailViewModel { Description = DescriptionEditor.Text, Name = TitleEntry.Text, RegisterTime = DateTime.Now, UserId = Constants.userId };
                  var result = await projectManager.PostAsync(newProject);
                  await Navigation.PopPopupAsync();
                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("New project added.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Project can not be added.");
            }
      }
}