namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;

      /// <summary>
      /// Documentation class was created to use Documentation table in the project 
      /// Metadatatype is used to connect validation rules and documentation entity
      /// </summary>
      [MetadataType(typeof(Documenation_Validation))]
      public partial class Documentation : IEntity {
            public int DocumentationId { get; set; }

            //To relate table with Project or Task
            public int? RelationId { get; set; }
            //Documentation Url which can be google drive link etc.
            public string DocumentationURL { get; set; }
            //To control if documentation connect with project or task
            public bool? IsProject { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }

            public virtual Project Project { get; set; }

            public virtual Task Task { get; set; }
      }
}
