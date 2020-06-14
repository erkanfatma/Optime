using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Popups {
      //To add new board to the project
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AddBoardPopup : Rg.Plugins.Popup.Pages.PopupPage {
            BoardManager boardManager = new BoardManager();
            int selectedProjectId;
            public AddBoardPopup(int projectId) {
                  InitializeComponent();
                  selectedProjectId = projectId;
            }


            private async void AddBoard_Clicked(object sender, EventArgs e) {
                  BoardViewModel newBoard = new BoardViewModel { Name = NameEntry.Text, ProjectId = selectedProjectId };
                  var result = await boardManager.PostAsync(newBoard);
                  await Navigation.PopPopupAsync();
                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("New board added.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Board can not be added.");
            }
      }
}