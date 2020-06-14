using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views {
      //To register application
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class RegisterPage : ContentPage {
            public RegisterPage() {
                  InitializeComponent();
            }

        private void LoginButton_Clicked(object sender, EventArgs e) {
                  App.Current.MainPage = new LoginPage();
            }

            private void RegisterButton_Clicked(object sender, EventArgs e) {

            }
      }
}