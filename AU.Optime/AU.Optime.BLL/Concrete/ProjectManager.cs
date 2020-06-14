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
      public class ProjectManager : IProjectService {
            private readonly IProjectDal _projectDal;
            public ProjectManager(IProjectDal projectDal) => _projectDal = projectDal;

            //To add new object
            public void AddProject(Project project) {
                  project.RegisterTime = DateTime.Now;
                  _projectDal.Add(project);
            }
            //To delete selected object
            public void DeleteProject(Project project) => _projectDal.Delete(project);

            //To get one object with its id
            public Project GetProject(int? id) => _projectDal.Get(c => c.ProjectId == id);

            //To list all objects
            public List<Project> GetProjects() => _projectDal.GetAll();
            //To list objects depend on userid
            public List<Project> GetProjectsByUserId(int? userId) {
                  if(userId is null) {
                        throw new ArgumentNullException(nameof(userId));
                  }
                  throw new ArgumentNullException(nameof(userId));
            }

            //To update selected object
            public void UpdateProject(Project project) => _projectDal.Update(project);
      }
}
