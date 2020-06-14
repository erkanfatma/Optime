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
      //To build services to reach Task objects from mobile devices
      [RoutePrefix("api/tasks")]
      public class TasksController : BaseController {
            ApiResult result = new ApiResult();
            private readonly ITaskService _taskService;
            public TasksController(ITaskService taskService) => _taskService = taskService;

            [HttpGet, Route("")]
            public ApiResult GetTasks() {
                  try {
                        result.Result = true;
                        result.Data = _taskService.GetTasks().Select(x => new TaskViewModel { Description = x.Description, DueTime = x.DueTime, TaskId = x.TaskId, Title = x.Title, UserId = x.UserId, IsPomodoro = x.IsPomodoro, SessionTime = x.SessionTime, Status = x.Status }).ToList();
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("tasksbyid/{id:int}/{type:alpha}")]
            public ApiResult GetTasksById(int id, string type) {
                  try {
                        result.Result = true; 
                        result.Data = _taskService.GetTasksById(id, type).Select(x => new TaskViewModel { Description = x.Description, DueTime = x.DueTime, TaskId = x.TaskId, Title = x.Title, UserId = x.UserId, IsPomodoro = x.IsPomodoro, Status = x.Status, SessionTime = x.SessionTime }).ToList();
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpGet, Route("task/{id:int}")]
            public ApiResult GetTask(int id) {
                  try {
                        result.Result = true;
                        //var task = _taskService.GetTask(id);
                        var task = _taskService.GetTaskwithDetails(id);
                        result.Data = new TaskDetailViewModel { BoardId = task.BoardId, Description = task.Description, DueTime = task.DueTime, IsComplex = task.TaskDetail.IsComplex, IsDelayed = task.TaskDetail.IsDelayed, IsPomodoro = task.IsPomodoro, IsReminder = task.IsReminder, IsRepeater = task.TaskDetail.IsRepeater, PriorityNumber = task.PriorityNumber, ProjectId = task.ProjectId, RegisterTime = task.TaskDetail.RegisterTime, ScheduleTime = task.ScheduleTime, SessionTime = task.SessionTime, Status = task.Status, SubTaskNumber = task.SubTaskNumber, TaskId = task.TaskId, Title = task.Title, UserId = task.UserId };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPut, Route("edittask")]
            public ApiResult PutTask([FromBody]TaskDetailViewModel model) {
                  try {
                        result.Result = true;
                        _taskService.UpdateTask(new Task { BoardId = model.BoardId, Description = model.Description, DueTime = model.DueTime, IsPomodoro = model.IsPomodoro, IsReminder = model.IsReminder, PriorityNumber = model.PriorityNumber, ProjectId = model.ProjectId, ScheduleTime = model.ScheduleTime, SessionTime = model.SessionTime, Status = model.Status, SubTaskNumber = model.SubTaskNumber, TaskId = model.TaskId, Title = model.Title, UserId = model.UserId, TaskDetail = new TaskDetail { IsComplex = model.IsComplex, TaskId = model.TaskId, IsDelayed = model.IsDelayed, IsRepeater = model.IsRepeater } });
                        result.Data = "Task updated";
                        result.Message = "Success";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPost, Route("addtask")]
            public ApiResult PostTask(TaskDetailViewModel model) {
                  try {
                        result.Result = true;
                        _taskService.AddTask(new Task { BoardId = model.BoardId, Description = model.Description, DueTime = model.DueTime, IsPomodoro = model.IsPomodoro, IsReminder = model.IsReminder, PriorityNumber = model.PriorityNumber, ProjectId = model.ProjectId, ScheduleTime = model.ScheduleTime, SessionTime = model.SessionTime, Status = model.Status, SubTaskNumber = model.SubTaskNumber, Title = model.Title, UserId = model.UserId, TaskDetail = new TaskDetail { IsComplex = model.IsComplex, IsDelayed = model.IsDelayed, IsRepeater = model.IsRepeater } });
                        result.Data = "Task added.";
                        result.Message = "Success";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpDelete, Route("deletetask/{id:int}")]
            public ApiResult DeleteTask(int id) {
                  try {
                        result.Result = true;
                        _taskService.DeleteTask(new Task { TaskId = id });
                        result.Data = "Task deleted";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }
      }
}
