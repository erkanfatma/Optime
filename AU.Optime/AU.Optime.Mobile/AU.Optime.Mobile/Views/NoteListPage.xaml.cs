using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using AU.Optime.Mobile.Views.Popups;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To list all notes
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class NoteListPage : ContentPage {
            NoteManager noteManager = new NoteManager();
            IEnumerable<NoteViewModel> noteList = new List<NoteViewModel>();
            public NoteListPage() {
                  InitializeComponent();
                  listIndicator.IsRunning = true;
                  listIndicator.IsVisible = true;
                  LoadDataAsync();
            }

            private async void LoadDataAsync() {
                  noteList = await noteManager.GetNotesByUserId(Constants.userId);

                  if(noteList.Count()<1) {
                        emptyMessage.IsVisible = true;
                        emptyMessage.Text = "Note not found";
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  } else {
                        emptyMessage.IsVisible = false;
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  }
                  lstNotes.ItemsSource = noteList.OrderByDescending(x => x.RegisterTime);
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  NoteViewModel selected = (NoteViewModel)e.SelectedItem;
                  Navigation.PushAsync(new NoteDetailPage(selected.NoteId), false);
                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }

            private void AddButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushPopupAsync(new AddNotePopup());
            }
      }
}