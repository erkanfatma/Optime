using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Entities.ComplexTypes {
      /// <summary>
      /// Schedule model is to show schedule properties comes from task 
      /// Used in schedule algroithm 
      /// </summary>
      public class ScheduleModel {
            public int SubTaskId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public TimeSpan SessionTime { get; set; }
            public DateTime ScheduleTime { get; set; }
      }
}
