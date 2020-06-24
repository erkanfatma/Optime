using AU.Optime.Core.DataAccess.EntityFramework;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.DAL.Concrete.EntityFramework {
      //To execute CRUD operations depend on SubTask object
      public class EfSubTaskDal : EFEntityRepositoryBase<SubTask, OptimeContext>, ISubTaskDal {
            //specific operations
      }
}
