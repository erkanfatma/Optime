using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //to show account and update its properties
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AccountPage : ContentPage {
            UserManager userManager = new UserManager();
            UserDetailViewModel user = new UserDetailViewModel();
            public AccountPage() {
                  InitializeComponent();
                  LoadDataAsync();
            }

            private async void LoadDataAsync() {
                  user = await userManager.Get(Constants.userId);
                  this.Title = user.FullName;
                  this.BindingContext = user;
                  FullNameEntry.Text = user.FullName;
                  UsernameEntry.Text = user.Username;
                  EmailEntry.Text = user.Email;
                  PasswordEntry.Text = user.Password;
                  WakingTimePicker.Time = (TimeSpan)user.WakingTime;
                  SleepingTimePicker.Time = (TimeSpan)user.SleepingTime;
                  EndWorkTimePicker.Time = (TimeSpan)user.EndWorkingTime;
                  BeginWorkTimePicker.Time = (TimeSpan)user.BeginWorkingTime;
                  BirthDatePicker.Date = Convert.ToDateTime(user.BirthDate);
            }

            private async void SaveButton_Clicked(object sender, EventArgs e) {
                  //await userManager.PutAsync(user);
                  DependencyService.Get<IMessage>().ShortAlert("Account updated.");
            }
      }
}