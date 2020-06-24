using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Note object to pass object from service to mobile
      public class NoteViewModel {
            public int NoteId { get; set; }
            public int? UserId { get; set; }
            public string Description { get; set; }
            public bool? IsImportant { get; set; }
            public DateTime? RegisterTime { get; set; }

      }
}