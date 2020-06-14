using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Documentation object to pass object from service to mobile
      public class DocumentationViewModel {
            public int DocumentationId { get; set; }
            public int? RelationId { get; set; }
            public string DocumentationURL { get; set; }
            public bool? IsProject { get; set; }
            public DateTime? RegisterTime { get; set; }

      }
}