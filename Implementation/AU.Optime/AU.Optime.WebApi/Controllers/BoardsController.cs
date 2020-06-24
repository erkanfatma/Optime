using AU.Optime.BLL.Abstract;
using AU.Optime.Entities.Concrete;
using AU.Optime.WebApi.Models;
using AU.Optime.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace AU.Optime.WebApi.Controllers {
      //To build services to reach Board objects from mobile devices
      [RoutePrefix("api/boards")]
      public class BoardsController : BaseController {
            ApiResult result = new ApiResult();
            private readonly IBoardService _boardService;
            public BoardsController(IBoardService boardService) => _boardService = boardService;

            [HttpGet, Route("")]
            public ApiResult GetBoards() {
                  try {
                        result.Result = true;
                        List<BoardViewModel> boards = _boardService.GetBoards().Select(c => new BoardViewModel { BoardId = c.BoardId, Name = c.Name, ProjectId = c.ProjectId }).ToList();
                        result.Data = boards;
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("getboardsbyproject/{projectId:int}")]
            public ApiResult GetBoardsByProject(int projectId) {
                  try {
                        result.Result = true;
                        List<BoardViewModel> boards = _boardService.GetBoardsByProjectId(projectId).Select(c => new BoardViewModel { BoardId = c.BoardId, Name = c.Name, ProjectId = c.ProjectId }).ToList();
                        result.Data = boards;
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;

            }

            [ResponseType(typeof(ApiResult)), HttpGet, Route("board/{id:int}")]
            public ApiResult GetBoard(int id) {
                  try {
                        result.Result = true;
                        var board = _boardService.GetBoard(id);
                        result.Data = new BoardViewModel { BoardId = board.BoardId, Name = board.Name, ProjectId = board.ProjectId };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPut, Route("editboard")]
            public ApiResult PutBoard([FromBody]BoardViewModel model) {
                  try {
                        result.Result = true;
                        _boardService.UpdateBoard(new Board { BoardId = model.BoardId, Name = model.Name, ProjectId = model.ProjectId });
                        result.Data = "Board updated.";
                        result.Message = "Success";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPost, Route("addboard")]
            public ApiResult PostBoard(BoardViewModel model) {
                  try {
                        result.Result = true;
                        _boardService.AddBoard(new Board { Name = model.Name, ProjectId = model.ProjectId });
                        result.Data = "Board added.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;

            }

            [ResponseType(typeof(ApiResult)), HttpDelete, Route("deleteboard/{id:int}")]
            public ApiResult DeleteBoard(int id) {
                  try {
                        result.Result = true;
                        _boardService.DeleteBoard(new Board { BoardId = id });
                        result.Data = "Board deleted.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }
      }
}
