using System;
using System.Collections.Generic;
using System.Text;

namespace AU.Optime.Mobile.CustomControls.ToastMessageService {
      //Custom control to create tost message in the Android layer
      public interface IMessage {
            void LongAlert(string message);
            void ShortAlert(string message);
      }
}
