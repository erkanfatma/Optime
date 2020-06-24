using Xamarin.Forms;

namespace AU.Optime.Mobile.CustomControls {
      //Custom entry to create a property to specify if entry contains line, line color of the entry and focus line color of the entry
      public class CustomEntry : Entry {

            public static readonly BindableProperty ContainsLineProperty = BindableProperty.Create<CustomEntry, bool>(p => p.IsLine, true);

            public static readonly BindableProperty LineColorProperty = BindableProperty.Create<CustomEntry, Color>(p => p.LineColor, Color.Black /*Color.FromHex("#838383")*/);

            public static readonly BindableProperty FocusLineColorProperty = BindableProperty.Create<CustomEntry, Color>(c => c.FocusLineColor, Color.FromHex("#FFC107"));


            public bool IsLine {
                  get { return (bool)GetValue(ContainsLineProperty); }
                  set { SetValue(ContainsLineProperty, value); }
            }
            public Color LineColor {
                  get { return (Color)GetValue(LineColorProperty); }
                  set { SetValue(LineColorProperty, value); }
            }
            public Color FocusLineColor {
                  get { return (Color)GetValue(FocusLineColorProperty); }
                  set { SetValue(FocusLineColorProperty, value); }
            }

      }
}
