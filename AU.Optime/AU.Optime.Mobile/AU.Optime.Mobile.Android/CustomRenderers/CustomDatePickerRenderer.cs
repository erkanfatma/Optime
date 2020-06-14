using Android.Widget;
using AU.Optime.Mobile.CustomControls;
using AU.Optime.Mobile.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePicker = Xamarin.Forms.DatePicker;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace AU.Optime.Mobile.Droid.CustomRenderers {
      //To connect mobile layer and android layer for date picker
      public class CustomDatePickerRenderer : DatePickerRenderer {
            protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e) {
                  base.OnElementChanged(e);

                  CustomDatePicker datePicker = (CustomDatePicker)Element;


                  if(e.OldElement == null) {
                        Control.Background = null;

                        var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                        LayoutParameters = layoutParams;
                        Control.LayoutParameters = layoutParams;
                  }

            }
      }
}