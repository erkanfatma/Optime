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
      //To list project boards
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ProjectBoardListPage : ContentPage {
            BoardManager boardManager = new BoardManager();
            IEnumerable<BoardViewModel> boardList = new List<BoardViewModel>();
            int selectedProjectId;
            public ProjectBoardListPage(int projectId) {
                  InitializeComponent();
                  LoadDataAsync(projectId);
                  selectedProjectId = projectId;
                 
            }

            private async void LoadDataAsync(int projectId) {
                  boardList = await boardManager.GetBoardsByProject(projectId);
                  lstBoards.ItemsSource = boardList;
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  BoardViewModel selected = (BoardViewModel)e.SelectedItem;
                  
                  Navigation.PushAsync(new ProjectTaskListPage(selected.BoardId, "board"), false);
                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }

            private void AddButton_Clicked(object sender, EventArgs e) {
                  PopupNavigation.Instance.PushAsync(new AddBoardPopup(selectedProjectId), false);
            }
      }
}