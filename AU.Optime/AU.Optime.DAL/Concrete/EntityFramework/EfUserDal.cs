using AU.Optime.Core.DataAccess.EntityFramework;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.DAL.Concrete.EntityFramework {
      //To execute CRUD operations depend on User object
      public class EfUserDal : EFEntityRepositoryBase<User, OptimeContext>, IUserDal {
            //specific operations

            //To get user with detail informations depend on userid
            public User GetUserwithDetails(int id) {
                  using(var context = new OptimeContext()) {
                        return context.Users.Include("UserDetail").FirstOrDefault();
                  }
            }

            //Login operations
            public User Login(string email, string password) {
                  using(var context = new OptimeContext()) {
                        return context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                  }
            }
      }
}
