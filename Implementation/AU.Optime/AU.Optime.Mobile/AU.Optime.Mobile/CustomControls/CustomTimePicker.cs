using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AU.Optime.Mobile.CustomControls {
      public class CustomTimePicker : TimePicker {
            //custom timepicker to define if timepicker contains line
            public static readonly BindableProperty ContainsLineProperty = BindableProperty.Create<CustomEntry, bool>(p => p.IsLine, true);

            public bool IsLine {
                  get { return (bool)GetValue(ContainsLineProperty); }
                  set { SetValue(ContainsLineProperty, value); }
            }
      }
}
