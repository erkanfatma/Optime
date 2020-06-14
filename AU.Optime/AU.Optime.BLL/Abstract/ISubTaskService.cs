using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface ISubTaskService {
            //To get one object with its id
            SubTask GetSubTask(int? id);
            //To list all object
            List<SubTask> GetSubTasks();
            //To list objects depend on taskid
            List<SubTask> GetSubTasksByTask(int? taskId);
            //To add new object
            void AddSubTask(SubTask subTask);
            //To update selected object
            void UpdateSubTask(SubTask subTask);
            //To delete selected object
            void DeleteSubTask(SubTask subTask);
      }
}
