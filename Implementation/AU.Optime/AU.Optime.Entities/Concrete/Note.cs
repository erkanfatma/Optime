namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;

      /// <summary>
      /// Note class is used to store Notes in the database and its usage in the code as Note class
      /// Metadatatype is used to connect validation rules of the note table
      /// </summary>

      [MetadataType(typeof(Note_Validation))]
      public partial class Note : IEntity {
            public int NoteId { get; set; }

            public int? UserId { get; set; }
            //Note detail text
            public string Description { get; set; }

            public bool? IsImportant { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }
            //Every note depend on a user.
            public virtual User User { get; set; }
      }
}
