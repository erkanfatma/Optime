using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To show details of the note and update
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class NoteDetailPage : ContentPage {
            NoteManager noteManager = new NoteManager();
            NoteViewModel note = new NoteViewModel();
            public NoteDetailPage(int noteId) {
                  InitializeComponent();
                  LoadDataAsync(noteId);
            }

            private async void LoadDataAsync(int noteId) {
                  note = await noteManager.Get(noteId);
                  this.BindingContext = note;
            }

            private async void SaveButton_Clicked(object sender, EventArgs e) {
                  NoteViewModel updatedNote = new NoteViewModel { Description = DescriptionEditor.Text, UserId = note.UserId, NoteId = note.NoteId, IsImportant = IsImportantOption.IsChecked, RegisterTime = note.RegisterTime};
                  var result= await noteManager.PutAsync(updatedNote);
                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("Note updated.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Note can not be updated.");
                  
                  Application.Current.MainPage = new NoteListPage();
            }

            private async void DeleteButton_Clicked(object sender, EventArgs e) {
                  var result = await noteManager.DeleteAsync(note);
                  if(result)
                        DependencyService.Get<IMessage>().ShortAlert("Note deleted.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Note can not be deleted.");

                  Application.Current.MainPage = new NoteListPage();
            }
      }
}