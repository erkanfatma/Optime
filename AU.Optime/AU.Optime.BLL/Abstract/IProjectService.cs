using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface IProjectService {
            //To get one object with its id
            Project GetProject(int? id);
            //To list all object
            List<Project> GetProjects();
            //To list objects depend on userid
            List<Project> GetProjectsByUserId(int? userId);
            //To add new object
            void AddProject(Project project);
            //To update selected object
            void UpdateProject(Project project);
            //To delete selected object
            void DeleteProject(Project project);
      }
}
