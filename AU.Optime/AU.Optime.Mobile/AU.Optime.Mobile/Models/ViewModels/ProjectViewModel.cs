using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //Project view model to get model from web services
      public class ProjectViewModel {
            public int ProjectId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
      }
}