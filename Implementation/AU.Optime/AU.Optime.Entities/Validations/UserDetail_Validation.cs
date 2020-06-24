using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Entities.Validations {

      /// <summary>
      /// To define validation rules of user entity
      /// </summary>
      [Table("UserDetail")]
      public class UserDetail_Validation {
            public int UserId { get; set; }
            [Display(Name ="Birth Date")]
            public DateTime? BirthDate { get; set; }
            [Display(Name = "Admin")]
            public bool? IsAdmin { get; set; }
            [Display(Name = "Image")]
            public string ImageURL { get; set; }
            [Display(Name = "Working Begin Time")]
            public TimeSpan? BeginWorkingTime { get; set; }
            [Display(Name = "Working End Time")]
            public TimeSpan? EndWorkingTime { get; set; }

            [Column(TypeName = "smalldatetime")]
            [Display(Name = "Register Time")]
            public DateTime? RegisterTime { get; set; }
            [Display(Name = "Waking Time")]
            public TimeSpan? WakingTime { get; set; }
            [Display(Name = "Sleeping Time")]
            public TimeSpan? SleepingTime { get; set; }

            public virtual User User { get; set; }
      }
}
