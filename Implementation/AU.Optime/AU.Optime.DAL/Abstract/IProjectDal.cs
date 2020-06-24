using AU.Optime.Core.DataAccess;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.DAL.Abstract {
      //To implement Project objects operations
      public interface IProjectDal : IEntityRepository<Project> {
            //Specific operations
      }
}
