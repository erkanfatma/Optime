﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AU.Optime.WebApi.Models.ViewModels {
      // View model of Project object to pass object from service to mobile
      public class ProjectViewModel {
            public int ProjectId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
      }
}