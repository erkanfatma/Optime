using AU.Optime.Mobile.CustomControls.ToastMessageService;
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
      //to list schedule daily, monthly and weekly
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class ScheduleListPage : ContentPage {
            ScheduleManager scheduleManager = new ScheduleManager();
            SubTaskManager subTaskManager = new SubTaskManager();
            IEnumerable<ScheduleViewModel> schedules = new List<ScheduleViewModel>();
            public ScheduleListPage() {
                  InitializeComponent();
                  listIndicator.IsRunning = true;
                  listIndicator.IsVisible = true;
                  LoadDataAsync();
            }

            private async void LoadDataAsync(string time = "daily") {
                  if(time == "weekly") {
                        schedules = await scheduleManager.GetWeeklySchedule(Constants.userId);
                  } else if(time == "monthly") {
                        schedules = await scheduleManager.GetMonthlySchedule(Constants.userId);
                  } else if(time == "all") {
                        schedules = await scheduleManager.GetAllScheduleByUser(Constants.userId);
                  } else if(time == "daily") {
                        schedules = await scheduleManager.GetDailySchedule(Constants.userId);
                  } else {
                        schedules = await scheduleManager.GetDailySchedule(Constants.userId);
                  }
                   
                  if(schedules.Count() < 1) {
                        emptyMessage.IsVisible = true;
                        emptyMessage.Text = "Plan not found.";
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  } else {
                        emptyMessage.IsVisible = false;
                        listIndicator.IsVisible = false;
                        listIndicator.IsRunning = false;
                  }
                  lstTasks.ItemsSource = schedules;
            }

            private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
                  if(e.SelectedItem == null)
                        return;

                  ScheduleViewModel selected = (ScheduleViewModel)e.SelectedItem;
                  // Navigation.PushAsync(new TaskDetailPage(selected.TaskId), false);

                  ListView listView = (ListView)sender;
                  listView.SelectedItem = null;
            }

            private async void DoneButton_Clicked(object sender, EventArgs e) {
                  // TO DO: change task status
                  Button button = (Button)sender;
                  StackLayout listViewItem = (StackLayout)button.Parent;
                  Label label = (Label)listViewItem.Children[0];

                  int subTaskId = Convert.ToInt32(label.Text);

                  //Complete task operation
                  if(subTaskId != 0) {
                        var subTask = await subTaskManager.GetSubTask(subTaskId);
                        var result = await subTaskManager.PutAsync(new SubTaskViewModel { Title = subTask.Title, TaskId = subTask.TaskId, SubTaskId = subTask.SubTaskId, Status = true, ScheduleTime = subTask.ScheduleTime, SessionTime = subTask.SessionTime });
                        if(result.Result)
                              DependencyService.Get<IMessage>().ShortAlert("Task completed.");
                        else
                              DependencyService.Get<IMessage>().ShortAlert("Task can not be completed.");
                  }
                  LoadDataAsync();
            }

            private async void SnoozeButton_Clicked(object sender, EventArgs e) {
                  // TO DO: schedule at the beginning
                  Button button = (Button)sender;
                  StackLayout listViewItem = (StackLayout)button.Parent.Parent;
                  Label label = (Label)listViewItem.Children[0];

                  int subTaskId = Convert.ToInt32(label.Text);

                  //Delay operation
                  if(subTaskId != 0) {
                        var subTask = await subTaskManager.GetSubTask(subTaskId);
                        var result = await subTaskManager.PutAsync(new SubTaskViewModel { Title = subTask.Title, TaskId = subTask.TaskId, SubTaskId = subTask.SubTaskId, Status = false, ScheduleTime = subTask.ScheduleTime, SessionTime = subTask.SessionTime });
                        if(result.Result)
                              DependencyService.Get<IMessage>().ShortAlert("Task snoozed.");
                        else
                              DependencyService.Get<IMessage>().ShortAlert("Task can not be snoozed.");
                  }
                  LoadDataAsync();
            }

            private void AddButton_Clicked(object sender, EventArgs e) {
                  Navigation.PushPopupAsync(new AddTaskPopup());
            }

            private void MonthlyScheduleButton_Clicked(object sender, EventArgs e) {
                  LoadDataAsync("monthly");
            }

            private void WeeklyScheduleButton_Clicked(object sender, EventArgs e) {
                  LoadDataAsync("weekly");
            }

            private void DailyScheduleButton_Clicked(object sender, EventArgs e) {
                  LoadDataAsync("daily");
            }

            private void AllScheduleButton_Clicked(object sender, EventArgs e) {
                  LoadDataAsync("all");
            }
      }
}