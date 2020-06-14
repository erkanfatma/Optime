using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AU.Optime.Entities.Validations {
      [Table("SubTask")]
      public class SubTask_Validation {
            public int SubTaskId { get; set; }

            public int? TaskId { get; set; }

            [Display(Name ="Status")]
            public bool? Status { get; set; }
            [Display(Name = "Session Time")]
            [Required(ErrorMessage ="Session time is required")]
            public TimeSpan? SessionTime { get; set; }
            
            public virtual Task Task { get; set; }
      }
}
