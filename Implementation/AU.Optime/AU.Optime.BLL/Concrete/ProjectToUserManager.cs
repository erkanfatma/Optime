using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Data Access Layer
      public class ProjectToUserManager : IProjectToUserService {
            private readonly IProjectToUserDal _projectToUserDal;
            public ProjectToUserManager(IProjectToUserDal projectToUserDal) => _projectToUserDal = projectToUserDal;

            //To update selected object
            public void AddProjectToUser(ProjectToUser projectToUser) => _projectToUserDal.Add(projectToUser);

            //to delete selected object
            public void DeleteProjectToUser(ProjectToUser projectToUser) => _projectToUserDal.Delete(projectToUser);

            //To get projects depend on userid
            public List<ProjectToUser> GetProjectsByUserId(int? userId) {
                  if(userId is null) {
                        throw new ArgumentNullException(nameof(userId));
                  }
                  return _projectToUserDal.GetAll(x => x.UserId == userId);
            }

            //To get all objects
            public List<ProjectToUser> GetProjectToUsers() => _projectToUserDal.GetAll();

            //To get users depend on projectid
            public List<ProjectToUser> GetUsersByProjectId(int? projectId) {
                  if(projectId is null) {
                        throw new ArgumentNullException(nameof(projectId));
                  }
                  return _projectToUserDal.GetAll(x => x.ProjectId == projectId);
            }
            //To update selected object
            public void UpdateProjectToUser(ProjectToUser projectToUser) => _projectToUserDal.Update(projectToUser);
      }
}
