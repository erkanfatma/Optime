using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //Task view model to get model from web services
      public class TaskViewModel {
            public int TaskId { get; set; }
            public int? UserId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? DueTime { get; set; }
            public bool? Status { get; set; }
            public bool? IsPomodoro { get; set; }
            public TimeSpan? SessionTime { get; set; }
             

            public string State {
                  get {
                        string state = "Done";
                        if(Status == null || Status == false)
                              state = "Waiting";
                        return state;
                  }
            }

            public string PomodoroCondition {
                  get {
                        string condition = "No";
                        if(IsPomodoro == true)
                              condition = "Yes";
                        return condition;
                  }
            }
      }
}
