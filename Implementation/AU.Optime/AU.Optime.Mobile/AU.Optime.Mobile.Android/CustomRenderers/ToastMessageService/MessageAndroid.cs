
using Android.App;
using Android.Widget;
using AU.Optime.Mobile.CustomControls.ToastMessageService;
using AU.Optime.Mobile.Droid.CustomRenderers.ToastMessageService;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace AU.Optime.Mobile.Droid.CustomRenderers.ToastMessageService {
      //To connect mobile layer and android layer for toast message
      public class MessageAndroid : IMessage {
            public void LongAlert(string message) {
                  Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
            }

            public void ShortAlert(string message) {
                  Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
            }
      }
}