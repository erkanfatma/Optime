using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To add new task to the project
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AddTaskPage : ContentPage {
            TaskManager taskManager = new TaskManager();
            int? selectedBoardId, selectedProjectId;
            public AddTaskPage(int? boardId, int? projectId) {
                  InitializeComponent();
                  selectedBoardId = boardId;
                  selectedProjectId = projectId;
                  RegisterTimeLabel.Text = DateTime.Now.ToString("dd MMM yyyy");
            }

            private async void AddButton_Clicked(object sender, EventArgs e) {
                  TaskDetailViewModel task = new TaskDetailViewModel { UserId = Constants.userId, ProjectId = selectedProjectId, BoardId = selectedBoardId, Description = DescriptionEditor.Text, DueTime = DueTimeDatePicker.Date, IsComplex = ComplexCheckBox.IsChecked, IsPomodoro = PomodoroCheckBox.IsChecked, IsReminder = ReminderCheckBox.IsChecked, IsRepeater = RepeaterCheckBox.IsChecked, RegisterTime = DateTime.Now, SessionTime = SessionTimePicker.Time, Status = StatusCheckBox.IsChecked, Title = TitleEntry.Text };

                  MobileResult result = await taskManager.PostAsync(task);

                  if(result.Result)
                        DependencyService.Get<IMessage>().ShortAlert("Task added.");
                  else
                        DependencyService.Get<IMessage>().ShortAlert("Task can not added.");
            }
      }
}