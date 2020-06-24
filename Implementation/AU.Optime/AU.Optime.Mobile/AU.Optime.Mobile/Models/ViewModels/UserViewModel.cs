using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //User view model to get model from web services
      public class UserViewModel {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public string FullName { get; set; }
      }
}