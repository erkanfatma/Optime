using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AU.Optime.Mobile.CustomControls {
      public class CustomDatePicker : DatePicker {
            //To remove line at the bottom of the datepicker

            public static readonly BindableProperty ContainsLineProperty = BindableProperty.Create<CustomEntry, bool>(p => p.IsLine, true);

            public bool IsLine {
                  get { return (bool)GetValue(ContainsLineProperty); }
                  set { SetValue(ContainsLineProperty, value); }
            }
      }
}
