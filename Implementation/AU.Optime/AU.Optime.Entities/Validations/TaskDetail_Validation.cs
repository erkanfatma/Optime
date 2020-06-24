using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Entities.Validations {
      /// <summary>
      /// Validation rules for task detail table
      /// </summary>
      [Table("TaskDetail")]
      public class TaskDetail_Validation {
            public int TaskId { get; set; }
            [Display(Name ="Register Time")]
            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }
            [Display(Name = "Repeater")]
            public bool? IsRepeater { get; set; }
            [Display(Name = "Delayed")]
            public bool? IsDelayed { get; set; }
            [Display(Name = "Complex")]
            public bool? IsComplex { get; set; }

            public virtual Task Task { get; set; }
      }
}
