using AU.Optime.Core.DataAccess;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.DAL.Abstract {
      //To implement User objects operations
      public interface IUserDal : IEntityRepository<User> {
            //Specific operations

            //To get user  with user detail depend on userid 
            User GetUserwithDetails(int id);

            //Login operation
            User Login(string email, string password);
      }
}
