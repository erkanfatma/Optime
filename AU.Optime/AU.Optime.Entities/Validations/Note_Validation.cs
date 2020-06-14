using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Entities.Validations {
      //Configure validation rules of Note table
      [Table("Note")]
      public class Note_Validation {
            public int NoteId { get; set; }

            public int UserId { get; set; }

            [Display(Name ="Description")]
            [Required(ErrorMessage = "Description is required.")]
            public string Description { get; set; }

            [Display(Name ="Important")]
            public bool? IsImportant { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime RegisterTime { get; set; }

            public virtual User User { get; set; }
      }
}
