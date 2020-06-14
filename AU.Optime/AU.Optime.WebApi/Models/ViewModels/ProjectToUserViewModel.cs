using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of ProjectToUser object to pass object from service to mobile
      public class ProjectToUserViewModel {
            public int ProjectId { get; set; }
            public int UserId { get; set; }
            public bool? IsManager { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }

      }
}