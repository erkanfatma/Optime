using Android.Graphics.Drawables;
using Android.Text;
using AU.Optime.Mobile.CustomControls;
using AU.Optime.Mobile.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace AU.Optime.Mobile.Droid.CustomRenderers {
      //To connect mobile layer and android layer for editor
      public class CustomEditorRenderer : EditorRenderer {
            protected override void OnElementChanged(ElementChangedEventArgs<Editor> e) {
                  base.OnElementChanged(e);

                  if(Control != null) {
                        GradientDrawable gd = new GradientDrawable();
                        gd.SetColor(global::Android.Graphics.Color.Transparent);
                        this.Control.SetBackgroundDrawable(gd);
                        this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                        //  Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
                  }
            }
      }

}