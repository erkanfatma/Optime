using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Schedule tasks object to pass object from service to mobile
      public class ScheduleViewModel {
            public int SubTaskId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public TimeSpan SessionTime { get; set; }
            public DateTime ScheduleTime { get; set; }
      }
}