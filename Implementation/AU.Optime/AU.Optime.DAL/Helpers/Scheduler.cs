using AU.Optime.DAL.Concrete.EntityFramework;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using AU.Optime.Entities.ComplexTypes;

namespace AU.Optime.DAL.Helpers {

      /// <summary>
      /// Schedule Algorithm the create a plan using tasks
      /// </summary>
      public class Scheduler {
            EfUserDal userDal = new EfUserDal();
            EfTaskDal taskDal = new EfTaskDal();
            int _userId;

            TimeSpan wakingTime;
            TimeSpan sleepingTime;
            TimeSpan beginWorkTime;
            TimeSpan endWorkTime;
            TimeSpan busyTime;


            //To get user with userId
            public User GetUser() {
                  return userDal.GetUserwithDetails(_userId);
            }

            //Get Task and Details depend on user
            public List<Task> GetTasks() {
                  #region
                  //var list = taskDal.GetTaskwithFullDetailsByUser(_userId).Where(x => x.Status == false).ToList();
                  //foreach(var item in list) {
                  //      int num = item.SubTasks.Count;
                  //}
                  #endregion
                  return taskDal.GetTaskwithFullDetailsByUser(_userId).Where(x => x.Status == false).ToList();
                  
            }

            //To calculate available time of the user
            public TimeSpan AvailableTimeCalculator() {
                  TimeSpan availableTimeInDay = new TimeSpan();
                  User user = GetUser();
                  //Default waking time
                  wakingTime = new TimeSpan(8, 0, 0);
                  //Default sleeping time
                  sleepingTime = new TimeSpan(23, 0, 0);
                  //Assign working time as not defined. Assume user not working in default
                  beginWorkTime = new TimeSpan(0, 0, 0);
                  endWorkTime = new TimeSpan(0, 0, 0);
                  busyTime = new TimeSpan(0, 0, 0);

                  //Assigning waking time of user
                  if(user.UserDetail.WakingTime != null) {
                        wakingTime = TimeSpan.Parse(user.UserDetail.WakingTime.ToString());
                  }
                  //Assigning sleeping time of user
                  if(user.UserDetail.SleepingTime != null) {
                        sleepingTime = TimeSpan.Parse(user.UserDetail.SleepingTime.ToString());
                  }

                  //Assigning working time of user
                  if(user.UserDetail.BeginWorkingTime != null && user.UserDetail.EndWorkingTime != null) {
                        beginWorkTime = TimeSpan.Parse(user.UserDetail.BeginWorkingTime.ToString());
                        endWorkTime = TimeSpan.Parse(user.UserDetail.EndWorkingTime.ToString());
                        //Calculate busy time of user
                        busyTime = endWorkTime - beginWorkTime;
                  }

                  //If user sleeps after 00.00
                  if(wakingTime > sleepingTime) {
                        TimeSpan overTime = sleepingTime - new TimeSpan(0, 0, 0); //Calculating overtime
                        sleepingTime = new TimeSpan(23, 59, 0); // Assume user sleeps in 23.59
                        //Calculate available time in the day
                        availableTimeInDay = sleepingTime - wakingTime - busyTime + overTime + new TimeSpan(0, 1, 0);
                  } 
                  //If user sleeps before 00.00
                  else {
                        availableTimeInDay = sleepingTime - wakingTime - busyTime;
                  }

                  return availableTimeInDay;
            }
            
            #region CalculateScheduleList
            //Schedule algorithm to create a plan using tasks
            public List<ScheduleModel> CreateProgram(int userId) {
                  this._userId = userId;
                  List<ScheduleModel> schedule = new List<ScheduleModel>();
                  List<Task> availableTasks = new List<Task>();
                  List<SubTask> availableSubTasks = new List<SubTask>();

                  //To get not done tasks
                  availableTasks = GetTasks();
                  //To get availableHours in a day.
                  TimeSpan availableTimeDaily = AvailableTimeCalculator();

                  //get availableTask one by one to get subTasks of availableTask
                  foreach(var availableTask in availableTasks.Where(x => x.DueTime >= DateTime.Now)) {
                        //To add priority if duetime of tasks is close.
                        if(availableTask.DueTime == DateTime.Now)
                              availableTask.PriorityNumber = 1;
                        else if(availableTask.DueTime == DateTime.Now.AddDays(1))
                              availableTask.PriorityNumber = 2;
                        else if(availableTask.DueTime == DateTime.Now.AddDays(2))
                              availableTask.PriorityNumber = 3;
                        taskDal.Update(availableTask);

                        // If task is reminder, add scheduleList with it's due time. 5 minutes reminder.
                        if(availableTask.IsReminder == true) {
                              schedule.Add(new ScheduleModel { Description = availableTask.Description, ScheduleTime = Convert.ToDateTime(availableTask.DueTime), SessionTime = new TimeSpan(0, 5, 0), Status = "Reminder", Title = availableTask.Title, SubTaskId = 0 });
                        }
                        //If task is not reminder
                        else {
                              //To add not completed subtasks to list
                              //var subTaskList = subTaskDal.GetAll(x => x.Status !=true && x.TaskId == availableTask.TaskId);
                              foreach(var subTask in availableTask.SubTasks) {
                                    if(subTask.Status != true)
                                          availableSubTasks.Add(subTask);
                                    //availableSubTaskList.Add(new Tuple<SubTask, bool>(subTask, false));
                              }
                        }
                  }

                  //To get now datetime to assign tasks
                  DateTime scheduleDateTime = DateTime.Now;
                  //to get hour and mins
                  TimeSpan timeInDay = new TimeSpan(0, 0, 0); // TO DO GET TIME IN DAY !!!!!!

                  TimeSpan availableTimeInADay = availableTimeDaily;
                  //assign subtasks to schedule one by one.
                  foreach(var item in availableSubTasks.OrderBy(x => x.Task.PriorityNumber)) {
                        if(availableTimeInADay == new TimeSpan(0, 0, 0) && schedule.Count <= availableSubTasks.Count) {
                              scheduleDateTime.AddDays(1);
                              availableTimeInADay = availableTimeDaily;
                        }

                        //To get session time of subTask
                        TimeSpan subTaskSessionTime = new TimeSpan(item.SessionTime.Value.Hours, item.SessionTime.Value.Minutes, item.SessionTime.Value.Seconds);
                        // remove session time from available time in schedule day
                        availableTimeInADay.Subtract(subTaskSessionTime);

                        //assigning scheduleTime
                        DateTime subTaskScheduleTime = new DateTime(scheduleDateTime.Year, scheduleDateTime.Month, scheduleDateTime.Day, timeInDay.Hours, timeInDay.Minutes, timeInDay.Seconds);

                        schedule.Add(new ScheduleModel { Description = item.Task.Description, Title = item.Task.Title, ScheduleTime = subTaskScheduleTime, SessionTime = subTaskSessionTime, Status = "Waiting", SubTaskId = item.SubTaskId });

                        // If task contains pomodoro then add schedule a pomodoro time
                        if(item.Task.IsPomodoro == true) {
                              // calculate pomodoro time which is 5 minutes.
                              TimeSpan pomodoroTime = new TimeSpan(0, 5, 0);
                              // to add pomodoro time and model to schedule list.
                              schedule.Add(new ScheduleModel { Title = "Resting time", Description = "Resting time comes from pomodoro", ScheduleTime = subTaskScheduleTime.AddMinutes(25), SessionTime = pomodoroTime, Status = "Waiting", SubTaskId = 0 });
                              // remove session time from available time in schedule day
                              availableTimeInADay.Subtract(pomodoroTime);
                        }
                  }
                  return schedule;
            }
            #endregion
      }


}
