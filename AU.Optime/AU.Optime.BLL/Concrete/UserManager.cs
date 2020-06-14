using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Data Access Layer
      public class UserManager : IUserService {
            private readonly IUserDal _userDal;
            public UserManager(IUserDal userDal) => _userDal = userDal;

            //To add new object
            public void AddUser(User user) {
                  user.UserDetail.RegisterTime = DateTime.Now;
                  _userDal.Add(user);
            }

            //To delete selected object
            public void DeleteUser(User user) => _userDal.Delete(user);

            //To get one object with its id
            public User GetUser(int? id) {
                  if(id is null) {
                        throw new ArgumentNullException(nameof(id));
                  }

                  return _userDal.Get(x => x.UserId == id);
            }

            //To list all objects
            public List<User> GetUsers() => _userDal.GetAll();

            //To get object with its details
            public User GetUserwithDetails(int? id) {
                  if(id is null) {
                        throw new ArgumentNullException(nameof(id));
                  }
                  return _userDal.GetUserwithDetails(Convert.ToInt32(id));
            }

            //Login the application
            public User Login(string email, string password) => _userDal.Login(email, password);
            //To update selected object
            public void UpdateUser(User user) => _userDal.Update(user);
      }
}
