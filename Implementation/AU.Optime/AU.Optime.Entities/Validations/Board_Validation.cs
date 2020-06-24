using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AU.Optime.Entities.Validations {
      /// <summary>
      /// Class contains validation rules of the board entity.
      /// It contains data annotations to create validation rule messages.
      /// </summary>
      [Table("Board")]
      public class Board_Validation {
            public int BoardId { get; set; }

            public int? ProjectId { get; set; }

            [Required(ErrorMessage = "Board name is required")]
            [MaxLength(32, ErrorMessage = "Board name contains at most 32 characters.")]
            public string Name { get; set; }
            public virtual Project Project { get; set; }

            public virtual ICollection<Task> Tasks { get; set; }
      }
}
