using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Data Access Layer
      public class SubTaskManager : ISubTaskService {
            private readonly ISubTaskDal _subTaskDal;
            public SubTaskManager(ISubTaskDal subTaskDal) => _subTaskDal = subTaskDal;
            //To add new object
            public void AddSubTask(SubTask subTask) => _subTaskDal.Add(subTask);
            //To delete selected object
            public void DeleteSubTask(SubTask subTask) => _subTaskDal.Delete(subTask);
            //To get one object with its id
            public SubTask GetSubTask(int? id) {
                  if(id is null) {
                        throw new ArgumentNullException(nameof(id));
                  }

                  return _subTaskDal.Get(x => x.SubTaskId == id);
            }
            //To list all object
            public List<SubTask> GetSubTasks() => _subTaskDal.GetAll();

            //To list objects depend on taskid
            public List<SubTask> GetSubTasksByTask(int? taskId) {
                  if(taskId is null) {
                        throw new ArgumentNullException(nameof(taskId));
                  }
                  return _subTaskDal.GetAll(x => x.TaskId == taskId);
            }
            //To update selected object
            public void UpdateSubTask(SubTask subTask) => _subTaskDal.Update(subTask);
      }
}
