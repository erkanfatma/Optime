namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;
      /// <summary>
      /// Project class is used to show properties of the Project table in the database.
      /// Metadatatype is used to connect validation rules and the project entity 
      /// </summary>
      [MetadataType(typeof(Project_Validation))]
      public partial class Project : IEntity {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Project() {
                  Boards = new HashSet<Board>();
                  Documentations = new HashSet<Documentation>();
                  ProjectToUsers = new HashSet<ProjectToUser>();
                  Tasks = new HashSet<Task>();
            }

            public int ProjectId { get; set; }
            //Project name
            public string Name { get; set; }
            //Project desciption
            public string Description { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Project contains boards so that Project entity is related to Board entity
            public virtual ICollection<Board> Boards { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Project includes documentations, Project entity is related to Documentation entity
            public virtual ICollection<Documentation> Documentations { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Project may contains many users at the same time
            public virtual ICollection<ProjectToUser> ProjectToUsers { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Project can contains Tasks without boards
            public virtual ICollection<Task> Tasks { get; set; }
      }
}
