using Android.Widget;
using AU.Optime.Mobile.CustomControls;
using AU.Optime.Mobile.Droid.CustomRenderers;
using Xamarin.Forms; 

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRenderer))]
namespace AU.Optime.Mobile.Droid.CustomRenderers {
      [System.Obsolete]
      //To connect mobile layer and android layer for timepicker
      public class CustomTimePickerRenderer : Xamarin.Forms.Platform.Android.TimePickerRenderer {
            protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.TimePicker> e) {
                  base.OnElementChanged(e);

                  CustomTimePicker timePicker = (CustomTimePicker)Element;


                  if(e.OldElement == null) {
                        Control.Background = null;

                        var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                        LayoutParameters = layoutParams;
                        Control.LayoutParameters = layoutParams;
                  }

            }
      }
}


 