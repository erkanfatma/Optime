using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using AU.Optime.Mobile.Provider;
using AU.Optime.Mobile.Views.Main;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To login application
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class LoginPage : ContentPage {
            UserManager userManager = new UserManager();
            //private readonly IMemoryCache _cache;
            public LoginPage() {
                  InitializeComponent();
              //    _cache = new MemoryCache(new MemoryCacheOptions() { });
            }

            private void RegisterButton_Clicked(object sender, EventArgs e) {
                  App.Current.MainPage = new RegisterPage();
            }

            private async void LoginButton_Clicked(object sender, EventArgs e) {
                  IndicatorButton.IsVisible = true;
                  IndicatorButton.IsRunning = true;
                  MobileResult result = await userManager.LoginAsync(new LoginViewModel {
                        Email = EmailEntry.Text,
                        Password = PasswordEntry.Text
                  });
                  if(result.Result) {
                        UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(result.Data.ToString());
                        IndicatorButton.IsVisible = false;
                        IndicatorButton.IsRunning = false;
                        //_cache.Set("userid", user.UserId);
                        
                        //var userid = _cache.Get("userid");
                        //Application.Current.Properties["userid"] = user.UserId;
                        //Application.Current.Properties.Add("userid", user.UserId);
                        //Application.Current.Properties.Add("authority", "true");
                        //Application.Current.Properties.Add("fullname", user.FullName);
                        App.Current.MainPage = new AppShell();
                  } else {
                        IndicatorButton.IsVisible = false;
                        IndicatorButton.IsRunning = false;
                        ErrorMessageLabel.IsVisible = true;
                  }

            }


            //private async Task LoadDataAsync() {
            //      LoginViewModel loginModel = new LoginViewModel();
            //      loginModel.Email = txtEmail.Text;
            //      loginModel.Password = txtPassword.Text;
            //      var result = await manager.Login(loginModel);
            //      if(result.UserId != 0) {
            //            Application.Current.Properties.Add("userid", result.UserId);
            //            Application.Current.Properties.Add("fullname", result.FullName);
            //            Application.Current.Properties.Add("authority", true);
            //      } else {
            //            errorMessage.Text = "User can not found.";
            //      }
            //}

            //private async void OnLoginClicked(object sender, EventArgs e) {
            //      if(Application.Current.Properties.ContainsKey("authority") && Application.Current.Properties["authority"].Equals(true)) {
            //            App.Current.MainPage = new OptimeNavigationPage(new SchedulePage());
            //      } else {
            //            await LoadDataAsync();
            //            App.Current.MainPage = new LoginPage();
            //      }

            //}

      }
}