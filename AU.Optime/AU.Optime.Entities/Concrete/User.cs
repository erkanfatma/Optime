namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;

      /// <summary>
      /// To show users property in the system
      /// Metadatatype is used to connect validation rule and user entity
      /// </summary>
      [MetadataType(typeof(User_Validation))]
      public partial class User : IEntity {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public User() {
                  Notes = new HashSet<Note>();
                  ProjectToUsers = new HashSet<ProjectToUser>();
                  Tasks = new HashSet<Task>();
                  Tasks1 = new HashSet<Task>();
            }

            public int UserId { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Username { get; set; }

            public string FullName { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Users can have notes in the project
            public virtual ICollection<Note> Notes { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //To relate users with a project with many to many relationship
            public virtual ICollection<ProjectToUser> ProjectToUsers { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //It contains tasks depend on a different user
            public virtual ICollection<Task> Tasks { get; set; }

            //To detailed user properties
            public virtual UserDetail UserDetail { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Task> Tasks1 { get; set; }
      }
}
