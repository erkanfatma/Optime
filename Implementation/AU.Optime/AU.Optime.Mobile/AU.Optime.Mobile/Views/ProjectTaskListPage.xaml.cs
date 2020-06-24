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
      //To list project tasks
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ProjectTaskListPage : ContentPage {
            TaskManager taskManager = new TaskManager();
            IEnumerable<TaskViewModel> taskList = new List<TaskViewModel>();
            public ProjectTaskListPage(int id,string type) {
                  InitializeComponent();
                  listIndicator.IsRunning = true;
                  listIndicator.IsVisible = true;
                  taskTitleSearchBar.IsVisible = false;
                  LoadDataAsync(id,type);
            }

            private async void LoadDataAsync(int id,string type) {
                  taskList = await taskManager.GetTasksById(id, type);

                  if(taskList.Count() < 1) {
                        emptyMessage.IsVisible = true;
                        emptyMessage.Text = "Task not found";
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                        taskTitleSearchBar.IsVisible = false;
                  } else {
                        emptyMessage.IsVisible = false;
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                        taskTitleSearchBar.IsVisible = true;
                  }
                  lstTasks.ItemsSource = taskList;
            }

            private void AddButton_Clicked(object sender, EventArgs e) {
                  //TO  DO::
                  //Navigation.PushPopupAsync(new AddTaskPopup());
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  TaskViewModel selected = (TaskViewModel)e.SelectedItem;
                  // Navigation.PushAsync(new TaskDetailPage(selected.TaskId), false);

                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }

            private void OnTextChanged(object sender, TextChangedEventArgs e) {
                  var searchedTask = taskList.Where(x => x.Title.ToLower().Contains(taskTitleSearchBar.Text.ToLower())).ToList();
                  lstTasks.ItemsSource = searchedTask;
            }
      }
}