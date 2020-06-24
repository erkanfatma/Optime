using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Task object to pass object from service to mobile
      public class TaskViewModel {
            public int TaskId { get; set; }
            public int? UserId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? DueTime { get; set; }
            public bool? Status { get; set; }
            public bool? IsPomodoro { get; set; }
            public TimeSpan? SessionTime { get; set; }
      }
}