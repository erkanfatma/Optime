using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface IUserService {
            //To get one object with its id
            User GetUser(int? id);
            //To get object with details
            User GetUserwithDetails(int? id);
            //Login to application
            User Login(string email, string password);
            //To get all objects
            List<User> GetUsers();
            //To add new object
            void AddUser(User user);
            //To update selected object
            void UpdateUser(User user);
            //To delete selected object
            void DeleteUser(User user);
      }
}
