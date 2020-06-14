using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using Rg.Plugins.Popup.Extensions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Popups {
      //To add new note to the application
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AddNotePopup : Rg.Plugins.Popup.Pages.PopupPage {
            NoteManager manager = new NoteManager();
            public AddNotePopup() {
                  InitializeComponent();
            }

            private async void AddButton_Clicked(object sender, EventArgs e) {
                  NoteViewModel newNote = new NoteViewModel { Description = DescriptionEditor.Text, IsImportant = IsImportantOption.IsChecked, RegisterTime = DateTime.Now, UserId = Constants.userId };
                  var result = await manager.PostAsync(newNote);
                  await Navigation.PopPopupAsync();
                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("New note added.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Note can not be added.");
            }
      }
}