using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AU.Optime.Entities.Validations {
      /// <summary>
      /// To define validation rule of user entity
      /// </summary>
      [Table("User")]
      public class User_Validation {
            public int UserId { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [MaxLength(100, ErrorMessage ="Email contains at most 100 characters.")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
            [Required(ErrorMessage = "Username is required")]
            [MaxLength(40, ErrorMessage = "Username contains at most 40 characters.")]
            public string Username { get; set; }
            
            [Display(Name = "Name")]
            [MaxLength(100, ErrorMessage = "Name contains at most 100 characters.")]
            public string FullName { get; set; }

            public virtual ICollection<Note> Notes { get; set; }

            public virtual ICollection<ProjectToUser> ProjectToUsers { get; set; }

            public virtual ICollection<Task> Tasks { get; set; }

            public virtual UserDetail UserDetail { get; set; }

            public virtual ICollection<Task> Tasks1 { get; set; }
      }
}
