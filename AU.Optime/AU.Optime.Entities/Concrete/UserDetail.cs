namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;

      /// <summary>
      /// created for detail properties to User table in the database
      /// Metadatatype is used connect validation rules with userdetail table 
      /// </summary>
      [MetadataType(typeof(UserDetail_Validation))]
      public partial class UserDetail : IEntity {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserId { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? BirthDate { get; set; }

            //control if it is admin or general user
            public bool? IsAdmin { get; set; }

            public string ImageURL { get; set; }

            public TimeSpan? BeginWorkingTime { get; set; }

            public TimeSpan? EndWorkingTime { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? RegisterTime { get; set; }

            public TimeSpan? WakingTime { get; set; }

            public TimeSpan? SleepingTime { get; set; }

            public virtual User User { get; set; }
      }
}
