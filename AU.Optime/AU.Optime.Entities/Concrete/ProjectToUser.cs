namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;

      /// <summary>
      /// ProejctToUser entity is used to create many to many relationship with Project and User
      /// Project class was created to show table.
      /// Metadatatype is used to connect Validation rules of the table in the code and the entity 
      /// </summary>
      [MetadataType(typeof(ProjectToUser_Validation))]
      public partial class ProjectToUser : IEntity {
            [Key]
            [Column(Order = 0)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ProjectId { get; set; }

            [Key]
            [Column(Order = 1)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserId { get; set; }

            //Control if the user is manager
            public bool? IsManager { get; set; }
            //Table is related to Project
            public virtual Project Project { get; set; }
            //Table is related to User
            public virtual User User { get; set; }
      }
}
