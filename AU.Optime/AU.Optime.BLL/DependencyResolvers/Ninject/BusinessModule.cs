using AU.Optime.BLL.Abstract;
using AU.Optime.BLL.Concrete;
using AU.Optime.DAL.Abstract;
using AU.Optime.DAL.Concrete.EntityFramework;
using Ninject.Modules;

namespace AU.Optime.BLL.DependencyResolvers.Ninject {
      
      public class BusinessModule : NinjectModule { 
            //To bind object manager to object service and to bind object operations with Entity Framework (EF) technology module
            public override void Load() {
                  
                  //Note
                  Bind<INoteService>().To<NoteManager>().InSingletonScope();
                  Bind<INoteDal>().To<EfNoteDal>();

                  //Board
                  Bind<IBoardService>().To<BoardManager>().InSingletonScope();
                  Bind<IBoardDal>().To<EfBoardDal>();

                  //Documentation
                  Bind<IDocumentationService>().To<DocumentationManager>().InSingletonScope();
                  Bind<IDocumentationDal>().To<EfDocumentationDal>();

                  //Project
                  Bind<IProjectService>().To<ProjectManager>().InSingletonScope();
                  Bind<IProjectDal>().To<EfProjectDal>();

                  //Task
                  Bind<ITaskService>().To<TaskManager>().InSingletonScope();
                  Bind<ITaskDal>().To<EfTaskDal>();

                  //User
                  Bind<IUserService>().To<UserManager>().InSingletonScope();
                  Bind<IUserDal>().To<EfUserDal>();

                  //Subtask
                  Bind<ISubTaskService>().To<SubTaskManager>().InSingletonScope();
                  Bind<ISubTaskDal>().To<EfSubTaskDal>();

                  //ProjectToUser
                  Bind<IProjectToUserService>().To<ProjectToUserManager>().InSingletonScope();
                  Bind<IProjectToUserDal>().To<EfProjectToUserDal>();
            }
      }
}
