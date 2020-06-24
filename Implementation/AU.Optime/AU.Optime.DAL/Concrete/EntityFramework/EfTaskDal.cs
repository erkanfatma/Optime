using AU.Optime.Core.DataAccess.EntityFramework;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AU.Optime.DAL.Concrete.EntityFramework {
      //To execute CRUD operations depend on Task object
      public class EfTaskDal : EFEntityRepositoryBase<Task, OptimeContext>, ITaskDal {
            //specific operations

            //to get task with its details
            public Task GetTaskwithDetails(int id) {
                  using(var context = new OptimeContext()) {
                        return context.Tasks.Include("TaskDetail").Where(x => x.TaskId == id).FirstOrDefault();
                  }
            }

            //to get task with details depend on userid
            public List<Task> GetTaskwithDetailsByUser(int id) {
                  using(var context = new OptimeContext()) {
                        return context.Tasks.Include("TaskDetail").Where(x => x.UserId == id && x.ProjectId == null && x.BoardId == null).ToList();
                  }
            }

            //to get task and subtask depend on userid
            public List<Task> GetTaskwithFullDetailsByUser(int id) {
                  using(var context = new OptimeContext()) {
                        return context.Tasks.Include("SubTasks").Include("TaskDetail").Where(x => x.UserId == id && x.ProjectId == null && x.BoardId == null).ToList();
                  }
            }
      }
}
