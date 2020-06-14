using AU.Optime.Core.DataAccess;
using AU.Optime.Entities.Concrete;

namespace AU.Optime.DAL.Abstract {
      //To implement operations depend on object type which is Board
      public interface IBoardDal : IEntityRepository<Board> {
            //Specific operations
      }
}
