using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AU.Optime.Entities.Validations {
      /// <summary>
      /// To configure validation rules of the Project table
      /// </summary>
      [Table("Project")]
      public class Project_Validation {
            
            public int ProjectId { get; set; }
            [Display(Name = "Project Name")]
            [Required(ErrorMessage = "Project name is required.")]
            [MaxLength(50, ErrorMessage = "Project name contains at most 50 characters.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Project description is required.")]
            [Display(Name = "Description")]
            public string Description { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }

            public virtual ICollection<Board> Boards { get; set; }

            public virtual ICollection<Documentation> Documentations { get; set; }

            public virtual ICollection<ProjectToUser> ProjectToUsers { get; set; }

            public virtual ICollection<Task> Tasks { get; set; }
      }
}
