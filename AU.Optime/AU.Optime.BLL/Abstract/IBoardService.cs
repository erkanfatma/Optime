using AU.Optime.Entities.Concrete;
using System.Collections.Generic;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface IBoardService {
            //To get one object with its id
            Board GetBoard(int? id);
            //To list all object
            List<Board> GetBoards();
            //To list objects depend on projectid
            List<Board> GetBoardsByProjectId(int? projectId);
            //To add new object
            void AddBoard(Board board);
            //To update selected object
            void UpdateBoard(Board board);
            //To delete selected object
            void DeleteBoard(Board board);
      }
}
