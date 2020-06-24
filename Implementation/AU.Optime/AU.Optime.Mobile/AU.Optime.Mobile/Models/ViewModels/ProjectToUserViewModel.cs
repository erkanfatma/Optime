using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.Mobile.Models.ViewModels {
      //ProjectToUser view model to get model from web services
      public class ProjectToUserViewModel {
            public int ProjectId { get; set; }
            public int UserId { get; set; }
            public bool? IsManager { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }

            public string ManagerText {
                  get {
                        string result = "";
                        if(IsManager == true) {
                              result = "Manager";
                        }
                        return result;
                  }
            }

      }
}