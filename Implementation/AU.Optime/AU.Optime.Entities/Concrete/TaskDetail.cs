namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;

      /// <summary>
      /// To show detail of Task entity 
      /// Metadatatype data annotation is used to connect validation rules with table
      /// </summary>
      [MetadataType(typeof(TaskDetail_Validation))]
      public partial class TaskDetail : IEntity {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int TaskId { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }

            //To control if task repeats
            public bool? IsRepeater { get; set; }

            //To control if task is delayed
            public bool? IsDelayed { get; set; }

            //Control if task is complex that means task is break for more pieces to do task in different dates
            public bool? IsComplex { get; set; }

            public virtual Task Task { get; set; }
      }
}
