using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using Rg.Plugins.Popup.Extensions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Popups {
      //to add new task
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AddTaskPopup : Rg.Plugins.Popup.Pages.PopupPage {
            TaskManager manager = new TaskManager();
            public AddTaskPopup() {
                  InitializeComponent();
            }

            private async void OnAddTaskClicked(object sender, EventArgs e) {
                  var result = await manager.PostAsync(new TaskDetailViewModel { Title = taskName.Text, UserId = Constants.userId });
                  await Navigation.PopPopupAsync();
                  if(result.Result) {
                        DependencyService.Get<IMessage>().ShortAlert("New task added.");
                  } else {
                        DependencyService.Get<IMessage>().ShortAlert("Task can not be added.");
                  }
            }
      }
}