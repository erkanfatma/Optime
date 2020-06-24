using AU.Optime.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AU.Optime.Entities.Validations {
      [Table("Documentation")]
      /// <summary>
      /// Class contains validation rules of the documentation entity.
      /// It contains data annotations to create validation rule messages.
      /// </summary>
      public class Documenation_Validation {
            public int DocumentationId { get; set; }

            public int? RelationId { get; set; }

            [Required(ErrorMessage ="Documentation url is required")]
            public string DocumentationURL { get; set; }
            public bool? IsProject { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }

            public virtual Project Project { get; set; }

            public virtual Task Task { get; set; }
      }
}
