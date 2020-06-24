using AU.Optime.Mobile.Views;
using AU.Optime.Mobile.Views.Main;
using Microsoft.Extensions.Caching.Memory;
using Xamarin.Forms;

namespace AU.Optime.Mobile {
      public partial class App : Application {
           // private readonly IMemoryCache _cache;
            public App() {
                  //_cache = new MemoryCache(new MemoryCacheOptions() { });
                  InitializeComponent();
                  //if(Application.Current.Properties.ContainsKey("userid"))
                  //var userid = _cache.Get("userid");
                  //if(userid != null && userid != "0")
                  //MainPage = new AppShell();
                  MainPage = new LoginPage();
                  //else
                  //      App.Current.MainPage = new LoginPage();
            }

            protected override void OnStart() {
            }

            protected override void OnSleep() {
            }

            protected override void OnResume() {
            }
      }
}
