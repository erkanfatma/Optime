using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using AU.Optime.Mobile.CustomControls;
using AU.Optime.Mobile.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace AU.Optime.Mobile.Droid.CustomRenderers {
      //To connect mobile layer and android layer for entry
      public class CustomEntryRenderer : EntryRenderer {
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e) {
                  base.OnElementChanged(e);
                  CustomEntry entry = (CustomEntry)Element;

                  if(entry != null) {
                        if(entry.IsLine == false) {
                              Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                        } else if(entry.IsLine == true) {
                              if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                                    //Control.BackgroundTintList = ColorStateList.ValueOf(entry.LineColor.ToAndroid());

                                    e.NewElement.Unfocused += (sender, evt) => {
                                          if(Control != null) {
                                                Control.BackgroundTintList = ColorStateList.ValueOf(entry.LineColor.ToAndroid());
                                          }
                                    };
                                    e.NewElement.Focused += (sender, evt) => {
                                          if(Control != null) {
                                                Control.BackgroundTintList = ColorStateList.ValueOf(entry.FocusLineColor.ToAndroid());
                                          }
                                    };

                              } else {
                                    //Control.Background.SetColorFilter(entry.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);

                                    e.NewElement.Unfocused += (sender, evt) => {
                                          if(Control != null) {
                                                Control.BackgroundTintList = ColorStateList.ValueOf(entry.LineColor.ToAndroid());
                                          }
                                    };
                                    e.NewElement.Focused += (sender, evt) => {
                                          if(Control != null) {
                                                Control.BackgroundTintList = ColorStateList.ValueOf(entry.FocusLineColor.ToAndroid());
                                          }
                                    };
                              }

                        }
                  }
            }

      }
}
