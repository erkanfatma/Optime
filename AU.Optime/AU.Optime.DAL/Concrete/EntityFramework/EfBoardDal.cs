using AU.Optime.Core.DataAccess.EntityFramework;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;

namespace AU.Optime.DAL.Concrete.EntityFramework {
      //To execute CRUD operations depend on Board object
      public class EfBoardDal : EFEntityRepositoryBase<Board, OptimeContext>, IBoardDal {
            //Specific operations are defined here
      }
}
