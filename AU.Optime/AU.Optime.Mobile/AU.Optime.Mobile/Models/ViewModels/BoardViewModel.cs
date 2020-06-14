using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //Board view model to get model from web services
      public class BoardViewModel {
            public int BoardId { get; set; }
            public int? ProjectId { get; set; }
            public string Name { get; set; }

      }
}