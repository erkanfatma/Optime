using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Helpers;
using AU.Optime.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Scheduler algorithm
      public class ScheduleManager : IScheduleService {
            Scheduler _scheduler = new Scheduler();

            //to get all schedule by user
            public List<ScheduleModel> GetAllByUserId(int? userId) {
                  if(userId is null) {
                        throw new ArgumentNullException(nameof(userId));
                  }

                  return _scheduler.CreateProgram(Convert.ToInt32(userId));
            }

            //to get daily schedule list depend on user
            public List<ScheduleModel> GetDaily(int? userId) {
                  if(userId is null) {
                        throw new ArgumentNullException(nameof(userId));
                  }

                  return _scheduler.CreateProgram(Convert.ToInt32(userId)).Where(x => x.ScheduleTime.Day == DateTime.Now.Day).ToList();
            }

            //to get monthly schedule list depend on user
            public List<ScheduleModel> GetMonthly(int? userId) {
                  if(userId is null) {
                        throw new ArgumentNullException(nameof(userId));
                  }
                  return _scheduler.CreateProgram(Convert.ToInt32(userId)).Where(x => x.ScheduleTime.Month == DateTime.Now.Month).ToList();
            }

            //to get weekly schedule list depend on user
            public List<ScheduleModel> GetWeekly(int? userId) {
                  if(userId is null) {
                        throw new ArgumentNullException(nameof(userId));
                  }
                  return _scheduler.CreateProgram(Convert.ToInt32(userId)).Where(x => x.ScheduleTime <= DateTime.Now.AddDays(7)).ToList();

            }

            //to delay tasks from schedule list
            public void UpdateScheduleModel(ScheduleModel model) {
                  
                   _scheduler.CreateProgram(Convert.ToInt32(model.SubTaskId));
            }
             
      }
}
