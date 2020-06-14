using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //Note view model to get model from web services
      public class NoteViewModel {
            public int NoteId { get; set; }
            public int? UserId { get; set; }
            public string Description { get; set; }
            public bool? IsImportant { get; set; }
            public DateTime? RegisterTime { get; set; }

      }
}