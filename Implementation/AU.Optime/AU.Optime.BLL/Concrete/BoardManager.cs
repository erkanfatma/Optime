using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Data Access Layer
      public class BoardManager : IBoardService {
            private readonly IBoardDal _boardDal;
            public BoardManager(IBoardDal boardDal) => _boardDal = boardDal;

            //To add new object
            public void AddBoard(Board board) => _boardDal.Add(board);

            //To delete selected object
            public void DeleteBoard(Board board) => _boardDal.Delete(board);

            //To get one object with its id
            public Board GetBoard(int? id) => _boardDal.Get(c => c.BoardId == id);

            //To list all object
            public List<Board> GetBoards() => _boardDal.GetAll();

            //To list objects depend on projectid
            public List<Board> GetBoardsByProjectId(int? projectId) {
                  if(projectId is null) {
                        throw new ArgumentNullException(nameof(projectId));
                  }
                  return _boardDal.GetAll(x => x.ProjectId == projectId);
            }

            //To update selected object
            public void UpdateBoard(Board board) => _boardDal.Update(board);


      }
}
