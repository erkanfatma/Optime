using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface ITaskService {
            //To get one object with its id
            Task GetTask(int? id);
            //To list all object
            List<Task> GetTasks();
            //To get object with details
            Task GetTaskwithDetails(int? id);

            //To list objects depend on id
            /*project -> project, board -> board , user -> user */  // for user = true, for project = false, for board = null
            List<Task> GetTasksById(int? Id, string type); 
            //To add new object
            void AddTask(Task task);
            //To update selected object
            void UpdateTask(Task task);
            //To delete selected object
            void DeleteTask(Task task);
      }
}
