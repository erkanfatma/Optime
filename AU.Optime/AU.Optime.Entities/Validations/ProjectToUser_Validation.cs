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
      /// To define validation rules for ProjectToUser table
      /// </summary>
      [Table("ProjectToUser")]
      public class ProjectToUser_Validation {
            
            public int ProjectId { get; set; }

            public int UserId { get; set; }

            [Display(Name ="Manager")]
            public bool? IsManager { get; set; }
            
            public virtual Project Project { get; set; }
            
            public virtual User User { get; set; }
      }
}
