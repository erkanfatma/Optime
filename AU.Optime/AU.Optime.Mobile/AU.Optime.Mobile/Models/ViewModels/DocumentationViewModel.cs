using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //Documentation view model to get model from web services
      public class DocumentationViewModel {
            public int DocumentationId { get; set; }
            public int? RelationId { get; set; }
            public string DocumentationURL { get; set; }
            public string Name { get; set; }
            public bool? IsProject { get; set; }
            public DateTime? RegisterTime { get; set; }

      }
}