namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;

      /// <summary>
      /// Board class was created against to Board table in the database and it's attributes are located inside of the class.
      /// Metadatatype is used to connect validation rules and the entity class
      /// </summary>
      
      [MetadataType(typeof(Board_Validation))]
      public partial class Board : IEntity {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Board() {
                  Tasks = new HashSet<Task>();
            }

            public int BoardId { get; set; }

            public int? ProjectId { get; set; }
            //Board Name
            public string Name { get; set; }
            //A board in the application belong to a project
            public virtual Project Project { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Board contains many tasks on the project.
            public virtual ICollection<Task> Tasks { get; set; }
      }
}
