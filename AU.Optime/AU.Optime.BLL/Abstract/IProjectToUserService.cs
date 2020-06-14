using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface IProjectToUserService {
            //To get all objects
            List<ProjectToUser> GetProjectToUsers();
            //To get projects depend on userid
            List<ProjectToUser> GetProjectsByUserId(int? userId);
            //To get users depend on projectid
            List<ProjectToUser> GetUsersByProjectId(int? projectId);
            //To add new object
            void AddProjectToUser(ProjectToUser projectToUser);
            //To update selected object
            void UpdateProjectToUser(ProjectToUser projectToUser);
            //to delete selected object
            void DeleteProjectToUser(ProjectToUser projectToUser);
      }
}
