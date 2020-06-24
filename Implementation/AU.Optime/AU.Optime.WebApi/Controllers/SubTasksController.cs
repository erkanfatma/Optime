using AU.Optime.BLL.Abstract;
using AU.Optime.Entities.Concrete;
using AU.Optime.WebApi.Models;
using AU.Optime.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AU.Optime.WebApi.Controllers {
      //To build services to reach SubTask objects from mobile devices
      [RoutePrefix("api/subtasks")]
      public class SubTasksController : BaseController {
            ApiResult result = new ApiResult();
            private readonly ISubTaskService _subTaskService;
            public SubTasksController(ISubTaskService subTaskService) => _subTaskService = subTaskService;

            [HttpGet, Route("{id:int}")]
            public ApiResult GetSubTasksByTask(int id) {
                  try {
                        result.Result = true;
                        result.Data = _subTaskService.GetSubTasksByTask(id).Select(x => new SubTaskViewModel { ScheduleTime = x.Task.ScheduleTime, SessionTime = x.SessionTime, Status = x.Status, SubTaskId = x.SubTaskId, TaskId = x.TaskId, Title = x.Task.Title }).ToList();
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(void)), HttpPut, Route("editsubtask")]
            public ApiResult PutNote([FromBody]SubTaskViewModel model) {
                  try {
                        result.Result = true;
                        _subTaskService.UpdateSubTask(new SubTask { SessionTime = model.SessionTime, Status = model.Status, SubTaskId = model.SubTaskId, TaskId = model.TaskId });
                        result.Data = "Subtask updated.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpGet, Route("subtask/{id:int}")]
            public ApiResult GetTask(int id) {
                  try {
                        result.Result = true;
                        var subTask = _subTaskService.GetSubTask(id);
                        result.Data = new SubTaskViewModel { SessionTime = subTask.SessionTime, Status = subTask.Status, SubTaskId = subTask.SubTaskId, TaskId = subTask.TaskId };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }
      }
}
