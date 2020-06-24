using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //TasDetail view model to get model from web services
      public class TaskDetailViewModel {
            public int TaskId { get; set; }
            public int? UserId { get; set; }
            public int? ProjectId { get; set; }
            public int? BoardId { get; set; }
            public string Title { get; set; } //
            public string Description { get; set; }//
            public DateTime? DueTime { get; set; }//
            public bool? Status { get; set; }//
            public byte? PriorityNumber { get; set; }
            public bool? IsReminder { get; set; } //?
            public DateTime? ScheduleTime { get; set; }
            public bool? IsPomodoro { get; set; } //
            public byte? SubTaskNumber { get; set; }
            public TimeSpan? SessionTime { get; set; } //
            public DateTime? RegisterTime { get; set; }//
            public bool? IsRepeater { get; set; }
            public bool? IsDelayed { get; set; }
            public bool? IsComplex { get; set; } //

      }
}