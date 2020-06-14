using System;
using System.Collections.Generic;
using System.Text;

namespace AU.Optime.Mobile.Models.ViewModels {
      //Schedule view model to get model from web services
      public class ScheduleViewModel {
            public int SubTaskId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public TimeSpan SessionTime { get; set; }
            public DateTime ScheduleTime { get; set; }
            public string DateOfSchedule { get { return ScheduleTime.ToString("dd MMM"); } }
            //public string DateOfSchedule { get { return ScheduleTime.ToString("{dd MMM yyyy}"); } }
            public string TimeOfSchedule { get { return ScheduleTime.ToString("hh:mm tt"); } }
            public string SessionTimeOfSchedule { get { return SessionTime.TotalMinutes + " mins"; } }
      }
}