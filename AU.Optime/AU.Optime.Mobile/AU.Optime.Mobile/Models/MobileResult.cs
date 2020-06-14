using System;
using System.Collections.Generic;
using System.Text;

namespace AU.Optime.Mobile.Models {
      /// <summary>
      /// Mobile result model to send and get data from web services
      /// </summary>
      public class MobileResult {
            public bool Result { get; set; }
            public object Data { get; set; }
            public string Message { get; set; }
      }
}
