namespace AU.Optime.Entities.Concrete {
      using AU.Optime.Core.Entities;
      using AU.Optime.Entities.Validations;
      using System;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;

      /// <summary>
      ///Task class is used to display Task table in the database
      ///Metadatatype is defined to connect validation rules and the entity
      /// </summary>
      [MetadataType(typeof(Task_Validation))]
      public partial class Task : IEntity {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Task() {
                  Documentations = new HashSet<Documentation>();
                  SubTasks = new HashSet<SubTask>();
                  Users = new HashSet<User>();
            }

            public int TaskId { get; set; }

            public int? UserId { get; set; }

            public int? ProjectId { get; set; }

            public int? BoardId { get; set; }

            //Name of task
            public string Title { get; set; }

            //details about the task
            public string Description { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? DueTime { get; set; }

            //Status of task to control if it's done
            public bool? Status { get; set; }

            //To control if task due time is close
            public byte? PriorityNumber { get; set; }

            //To control if task is reminder 
            //Task can be reminder like an alarm
            public bool? IsReminder { get; set; }

            [Column(TypeName = "smalldatetime")]
            public DateTime? ScheduleTime { get; set; }

            //To control if task has resting time
            public bool? IsPomodoro { get; set; }

            //Control how many subtask a task contains
            public byte? SubTaskNumber { get; set; }

            //How much time does task take
            public TimeSpan? SessionTime { get; set; }

            //Relate board if task belong the board inside of the project
            public virtual Board Board { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Task can contains documents.
            public virtual ICollection<Documentation> Documentations { get; set; }

            //Task can be belong to a project
            public virtual Project Project { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Every task contains subtasks
            public virtual ICollection<SubTask> SubTasks { get; set; }

            //More detail for task
            public virtual TaskDetail TaskDetail { get; set; }

            //Who created the task
            public virtual User User { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //Task can be assigned to many user
            public virtual ICollection<User> Users { get; set; }
      }
}
