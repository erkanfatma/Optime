
using System;
using Xamarin.Forms;

using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Main {
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AppMainPage : Xamarin.Forms.TabbedPage {
            public AppMainPage() {
                  InitializeComponent();
                  On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
                  LoadPages();
            }

            private void LoadPages() {
                  NavigationPage schedulePage = new NavigationPage(new ScheduleListPage());
                  schedulePage.IconImageSource = "ScheduleIcon2.png";
                  schedulePage.Title = "Schedule";
                  this.Children.Add(schedulePage);

                  NavigationPage taskPage = new NavigationPage(new TaskListPage());
                  taskPage.IconImageSource = "TaskIcon.png";
                  taskPage.Title = "Tasks";
                  this.Children.Add(taskPage);

                  NavigationPage projectPage = new NavigationPage(new ProjectListPage());
                  projectPage.IconImageSource = "ProjectIcon.png";
                  projectPage.Title = "Projects";
                  this.Children.Add(projectPage);

                  NavigationPage notePage = new NavigationPage(new NoteListPage());
                  notePage.IconImageSource = "NoteIcon.png";
                  notePage.Title = "Projects";
                  this.Children.Add(notePage);

                  NavigationPage accountPage = new NavigationPage(new AccountPage());
                  accountPage.IconImageSource = "AccountIcon.png";
                  accountPage.Title = "Account";
                  this.Children.Add(accountPage);

            }
      }
}
 