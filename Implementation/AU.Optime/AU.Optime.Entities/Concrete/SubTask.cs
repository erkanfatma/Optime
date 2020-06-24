namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.ComponentModel.DataAnnotations;

      /// <summary>
      /// Every task contains subtasks in the project so that, SubTask entity is generated to display in the database
      /// Metadatatype is used to define validation rules for SubTask table
      /// </summary>
      [MetadataType(typeof(SubTask_Validation))]
      public partial class SubTask : IEntity {
            public int SubTaskId { get; set; }

            public int? TaskId { get; set; }

            //To control if subtask done or waiting for done
            public bool? Status { get; set; }
            //How much time it takes to finish.
            public TimeSpan? SessionTime { get; set; }
            //Every subtask is related a task
            public virtual Task Task { get; set; }
      }
}
