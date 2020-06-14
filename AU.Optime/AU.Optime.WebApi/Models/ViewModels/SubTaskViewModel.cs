using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Subtask object to pass object from service to mobile
      public class SubTaskViewModel {
            public int SubTaskId { get; set; }
            public int? TaskId { get; set; }
            public bool? Status { get; set; }
            public TimeSpan? SessionTime { get; set; }
            public string Title { get; set; }
            public DateTime? ScheduleTime { get; set; }
      }
}