using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //SubTask view model to get model from web services
      public class SubTaskViewModel {
            public int SubTaskId { get; set; }
            public int? TaskId { get; set; }
            public bool? Status { get; set; }
            public TimeSpan? SessionTime { get; set; }
            public string Title { get; set; }
            public DateTime? ScheduleTime { get; set; }
      }
}