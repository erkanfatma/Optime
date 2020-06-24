using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //UserDetail view model to get model from web services
      public class UserDetailViewModel {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public string FullName { get; set; }
            public DateTime? BirthDate { get; set; }
            public bool? IsAdmin { get; set; }
            public string ImageURL { get; set; }
            public TimeSpan? BeginWorkingTime { get; set; }
            public TimeSpan? EndWorkingTime { get; set; }
            public DateTime? RegisterTime { get; set; }
            public TimeSpan? WakingTime { get; set; }
            public TimeSpan? SleepingTime { get; set; }
      }
}