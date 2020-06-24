using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of ProjectDetail object to pass object from service to mobile
      public class ProjectDetailViewModel {
            public int ProjectId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime? RegisterTime { get; set; }
            public int UserId { get; set; }
      }
}