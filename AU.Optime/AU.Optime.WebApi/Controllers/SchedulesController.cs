using AU.Optime.BLL.Abstract;
using AU.Optime.Entities.Concrete;
using AU.Optime.WebApi.Models;
using AU.Optime.WebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AU.Optime.WebApi.Controllers {
      //To build services to reach Schedule algorithm objects from mobile devices
      [RoutePrefix("api/schedules")]
      public class SchedulesController : BaseController {
            ApiResult result = new ApiResult();
            AU.Optime.BLL.Concrete.ScheduleManager _scheduleService = new BLL.Concrete.ScheduleManager();
            //private readonly IScheduleService _scheduleService;
            //public SchedulesController(IScheduleService scheduleService) => _scheduleService = scheduleService;

            // GET: api/schedules
            [HttpGet, Route("{userId:int}")]
            public ApiResult GetSchedules(int userId) {
                  try {
                        result.Result = true;
                        List<ScheduleViewModel> schedules = _scheduleService.GetAllByUserId(userId).Select(x => new ScheduleViewModel { Description = x.Description, ScheduleTime = x.ScheduleTime, SessionTime = x.SessionTime, Status = x.Status, SubTaskId = x.SubTaskId, Title = x.Title }).ToList();
                        result.Data = schedules;
                        result.Message = "Success.";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("daily/{userId:int}")]
            public ApiResult GetDailySchedules(int userId) {
                  try {
                        result.Result = true;
                        List<ScheduleViewModel> schedules = _scheduleService.GetDaily(userId).Select(x => new ScheduleViewModel { Description = x.Description, ScheduleTime = x.ScheduleTime, SessionTime = x.SessionTime, Status = x.Status, SubTaskId = x.SubTaskId, Title = x.Title }).ToList();
                        result.Data = schedules;
                        result.Message = "Success.";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("weekly/{userId:int}")]
            public ApiResult GetWeeklySchedules(int userId) {
                  try {
                        result.Result = true;
                        List<ScheduleViewModel> schedules = _scheduleService.GetWeekly(userId).Select(x => new ScheduleViewModel { Description = x.Description, ScheduleTime = x.ScheduleTime, SessionTime = x.SessionTime, Status = x.Status, SubTaskId = x.SubTaskId, Title = x.Title }).ToList();
                        result.Data = schedules;
                        result.Message = "Success.";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("monthly/{userId:int}")]
            public ApiResult GetMonhtlySchedules(int userId) {
                  try {
                        result.Result = true;
                        List<ScheduleViewModel> schedules = _scheduleService.GetMonthly(userId).Select(x => new ScheduleViewModel { Description = x.Description, ScheduleTime = x.ScheduleTime, SessionTime = x.SessionTime, Status = x.Status, SubTaskId = x.SubTaskId, Title = x.Title }).ToList();
                        result.Data = schedules;
                        result.Message = "Success.";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            //[HttpPut, Route("editschedule")]
            //public ApiResult PutSchedule([FromBody]ScheduleViewModel model) {

            //}
      }
}
