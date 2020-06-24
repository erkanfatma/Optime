using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To see details of task
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class TaskDetailPage : ContentPage {
            TaskManager taskManager = new TaskManager();
            TaskDetailViewModel task = new TaskDetailViewModel();

            public TaskDetailPage(int taskId) {
                  InitializeComponent();
                  LoadDataAsync(taskId);
            }

            private async void LoadDataAsync(int taskId) {
                  task = await taskManager.Get(taskId);
                  this.Title = task.Title;
                  this.BindingContext = task;

                  if(task.Status == true)
                        StatusCheckBox.IsChecked = true;

                  if(task.IsPomodoro == true)
                        PomodoroCheckBox.IsChecked = true;

                  if(task.IsReminder == true)
                        ReminderCheckBox.IsChecked = true;

                  if(task.IsComplex == true)
                        ComplexCheckBox.IsChecked = true;

                  if(task.IsRepeater == true)
                        RepeaterCheckBox.IsChecked = true;
            }

            private async void DeleteButton_Clicked(object sender, EventArgs e) {
                  TaskViewModel taskDeleteModel = new TaskViewModel { TaskId = task.TaskId };
                  var result = await taskManager.DeleteAsync(taskDeleteModel);
                  await Navigation.PopAsync();
                  if(result)
                        DependencyService.Get<IMessage>().ShortAlert("Task deleted.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Task can not deleted.");
            }

            private async void SaveButton_Clicked(object sender, EventArgs e) {
                  // TO DO : get update model
                  TaskDetailViewModel updatedTask = new TaskDetailViewModel { TaskId = task.TaskId, BoardId = task.BoardId, ProjectId = task.ProjectId, UserId = task.UserId, Description = DescriptionEditor.Text, DueTime = DueTimeDatePicker.Date, IsComplex = ComplexCheckBox.IsChecked, IsDelayed = task.IsDelayed, IsPomodoro = PomodoroCheckBox.IsChecked, IsReminder = ReminderCheckBox.IsChecked, IsRepeater = RepeaterCheckBox.IsChecked, PriorityNumber = task.PriorityNumber, RegisterTime = Convert.ToDateTime(RegisterTimeLabel.Text), ScheduleTime = task.ScheduleTime, /*SessionTime = (TimeSpan)SessionTimePicker.Time,*/ Status = StatusCheckBox.IsChecked, SubTaskNumber = task.SubTaskNumber, Title = TitleEntry.Text };
                  var result = await taskManager.PutAsync(updatedTask);
                  await Navigation.PopAsync();
                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("Task updated.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Task can not updated.");
            }
      }
}