using AU.Optime.DAL.Helpers;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace AU.ScheduleTest {
      //To test schedule algorithm
      public class Program {
            static void Main(string[] args) {
                  int userId = 1;
                  Scheduler scheduler = new Scheduler(userId);
                  
                  //Test user
                  User user = scheduler.GetUser();
                  Console.WriteLine(user.FullName +"\n");

                  //Test tasks
                  List<Task> tasks = scheduler.GetTasks();
                  foreach(var item in tasks) {
                  //      Console.WriteLine(item.Title + " * " + item.DueTime.ToString() + " - " + item.Description + "\n" + item.TaskDetail.IsRepeater);
                  }

                  //Test available time
                  var time = scheduler.AvailableTimeCalculator();
                  Console.WriteLine(time.ToString());
                  


                  Console.Read();

            }
      }
}
