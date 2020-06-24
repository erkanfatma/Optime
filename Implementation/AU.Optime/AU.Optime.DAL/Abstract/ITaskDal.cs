using AU.Optime.Core.DataAccess;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AU.Optime.DAL.Abstract {
      //To implement Task objects operations
      public interface ITaskDal : IEntityRepository<Task> {
            //Specific operations

            //To get a task with task detail object depend on task id
            Task GetTaskwithDetails(int id);
            //To get task with task detail object depend on user id
            List<Task> GetTaskwithDetailsByUser(int id);
      }
}
