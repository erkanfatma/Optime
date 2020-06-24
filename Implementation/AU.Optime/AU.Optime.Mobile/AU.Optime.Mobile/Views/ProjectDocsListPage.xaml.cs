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
      //To list project documents
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ProjectDocsListPage : ContentPage {
            DocumentManager docManager = new DocumentManager();
            IEnumerable<DocumentationViewModel> docList = new List<DocumentationViewModel>();
            public ProjectDocsListPage(int projectId) {
                  InitializeComponent();
                  listIndicator.IsRunning = true;
                  listIndicator.IsVisible = true;
                  LoadDataAsync(projectId);
            }

            private async void LoadDataAsync(int projectId) {
                  docList = await docManager.GetDocsByRelation(projectId, true);
                  if(docList.Count() < 1) {
                        emptyMessage.IsVisible = true;
                        emptyMessage.Text = "Document not found";
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  } else {
                        emptyMessage.IsVisible = false;
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  }
                  lstDocs.ItemsSource = docList;
            }

            private void lstDocs_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  TaskViewModel selected = (TaskViewModel)e.SelectedItem;
                  // Navigation.PushAsync(new TaskDetailPage(selected.TaskId), false);

                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }

            private void AddButton_Clicked(object sender, EventArgs e) {
                  //TO DO:
            }
      }
}