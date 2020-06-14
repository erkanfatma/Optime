using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Entities.Validations {
      [Table("Task")]
      public class Task_Validation {
            public int TaskId { get; set; }

            public int? UserId { get; set; }

            public int? ProjectId { get; set; }

            public int? BoardId { get; set; }

            [Display(Name ="Title")]
            [Required(ErrorMessage ="Title is required")]
            [MaxLength(50, ErrorMessage = "Title must contains at most 50 characters.")]
            public string Title { get; set; }

            [Display(Name ="Description")]
            public string Description { get; set; }

            [Column(TypeName = "smalldatetime")]
            [Display(Name = "Due Time")]
            public DateTime? DueTime { get; set; }

            public bool? Status { get; set; }
            [Display(Name ="Priority Number")]
            public byte? PriorityNumber { get; set; }

            [Display(Name = "Reminder")]
            public bool? IsReminder { get; set; }

            [Column(TypeName = "smalldatetime")]
            [Display(Name = "Schedule Time")]
            public DateTime? ScheduleTime { get; set; }

            [Display(Name = "Pomodoro")]
            public bool? IsPomodoro { get; set; }
            [Display(Name = "Number of Subtasks")]
            public byte? SubTaskNumber { get; set; }
            [Display(Name = "Session Time")]
            public TimeSpan? SessionTime { get; set; }

            public virtual Board Board { get; set; }

            public virtual ICollection<Documentation> Documentations { get; set; }

            public virtual Project Project { get; set; }

            public virtual ICollection<SubTask> SubTasks { get; set; }

            public virtual TaskDetail TaskDetail { get; set; }

            public virtual User User { get; set; }

            public virtual ICollection<User> Users { get; set; }
      }
}
