using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AU.Optime.Mobile.Views.Main
{
      [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class AppShell : Shell
      {
            public AppShell()
            {
                  InitializeComponent();
            }
      }
}