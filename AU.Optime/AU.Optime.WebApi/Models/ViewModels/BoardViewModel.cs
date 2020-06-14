using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Board object to pass object from service to mobile
      public class BoardViewModel {
            public int BoardId { get; set; }
            public int? ProjectId { get; set; }
            public string Name { get; set; }

      }
}