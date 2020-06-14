using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models {
      /// <summary>
      ///Viewmodel to send objects from Web API to mobile 
      ///If any error occured in the project result will be false and message contains error message.
      ///If data send correctly between mobile and Web API, result will be true and message contains Success message.
      /// </summary>
      public class ApiResult {
            public bool Result { get; set; }
            public object Data { get; set; }
            public string Message { get; set; }
      }
}