using AU.Optime.Core.DataAccess;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.DAL.Abstract {
      //To implement SubTask objects operations
      public interface ISubTaskDal : IEntityRepository<SubTask> {
            //Specific operations
      }
}
