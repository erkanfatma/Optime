using AU.Optime.BLL.Abstract;
using AU.Optime.DAL.Abstract;
using AU.Optime.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AU.Optime.BLL.Concrete {
      //Specify operations using Data Access Layer
      public class TaskManager : ITaskService {
            private readonly ITaskDal _taskDal;
            private readonly ISubTaskDal _subtaskDal;
            public TaskManager(ITaskDal taskDal, ISubTaskDal subtaskDal) {
                  _taskDal = taskDal;
                  _subtaskDal = subtaskDal;
            }
            //To add new object
            public void AddTask(Task task) {
                  task.TaskDetail.RegisterTime = DateTime.Now;
                  if(task.SessionTime == null)
                        task.SessionTime = new TimeSpan(0, 25, 0);
                  _taskDal.Add(task);

                  //To add subtask
                  #region SubTaskAdder
                  //control if task contains pomodoro
                  if(task.IsPomodoro == true) {
                        //if contains  then calculate subtask number which every subtask consist of 25 minutes
                        int subTaskCounter = Convert.ToInt32(task.SessionTime) / 25;
                        //if last task smaller than 25 mins
                        int additionalTime = Convert.ToInt32(task.SessionTime) % 25;
                        if(additionalTime != 0) {
                              _subtaskDal.Add(new SubTask() { TaskId = task.TaskId, SessionTime = new TimeSpan(0, additionalTime, 0) });
                        }
                        //add subtasks one by one
                        for(int i = 0; i < subTaskCounter; i++) {
                              _subtaskDal.Add(new SubTask() { TaskId = task.TaskId, SessionTime = new TimeSpan(0, 25, 0) });
                        }
                  } else {
                        _subtaskDal.Add(new SubTask() { TaskId = task.TaskId, SessionTime = task.SessionTime });
                  }

                  #endregion
            } 
            //To delete selected object
            public void DeleteTask(Task task) {
                  //To delete subtasks that is belong to deleted task
                  foreach(var item in _subtaskDal.GetAll(x => x.TaskId == task.TaskId)) {
                        _subtaskDal.Delete(item);
                  }
                  _taskDal.Delete(task);
            }

            //To get object depend on its id
            public Task GetTask(int? id) => _taskDal.Get(x => x.TaskId == id);

            //To list all tasks
            public List<Task> GetTasks() => _taskDal.GetAll();

            //To list objects depend on id
            /*project -> project, board -> board , user -> user */  // for user = true, for project = false, for board = null
            public List<Task> GetTasksById(int? Id, string type) {
                  List<Task> tasks = new List<Task>();
                  if(type == "user") {
                        //for user = true
                        tasks = _taskDal.GetAll(x => x.UserId == Id && x.ProjectId == null && x.BoardId == null);
                  } else if(type == "project") {
                        //for project = false
                        tasks = _taskDal.GetAll(x => x.ProjectId == Id);
                  } else if(type == "board") {
                        //for board = null
                        tasks = _taskDal.GetAll(x => x.BoardId == Id);
                  }
                  return tasks;
            }

            //To get task with its details
            public Task GetTaskwithDetails(int? id) {
                  if(id is null) {
                        throw new ArgumentNullException(nameof(id));
                  }
                  return _taskDal.GetTaskwithDetails(Convert.ToInt32(id));
            }

            //To update tasks
            public void UpdateTask(Task task) {
                  Task oldTask = GetTask(task.TaskId);

                  //control session time of task if changed
                  if(task.SessionTime > oldTask.SessionTime) {
                        //if new time is greater then calculate how many subtask will be added.
                        if(task.IsPomodoro == true) {
                              //if task contains pomodoro calculate subtask numbers
                              int newSubTaskCounter = (Convert.ToInt32(task.SessionTime) / 25) - (Convert.ToInt32(oldTask.SessionTime) / 25);
                              for(int i = 0; i < newSubTaskCounter; i++) {
                                    _subtaskDal.Add(new SubTask() { TaskId = task.TaskId, SessionTime = new TimeSpan(0, 25, 0) });
                              }
                        } else {
                              //if no pomodoro contains, then update the subtask session time
                              SubTask subTask = _subtaskDal.Get(x => x.TaskId == task.TaskId);
                              subTask.SessionTime = task.SessionTime;
                              _subtaskDal.Update(subTask);
                        }
                  } else if(task.SessionTime < oldTask.SessionTime) {
                        if(task.IsPomodoro == true) {
                              // control subtasks status 
                              // if subtask status is false or null, then calculate subtask number to delete. 
                              //delete subtask depend on subtask counter

                              int newSubTaskCounter = (Convert.ToInt32(oldTask.SessionTime) / 25) - (Convert.ToInt32(task.SessionTime) / 25);
                              int uncompletedSubTasks = _subtaskDal.GetAll(x => x.TaskId == task.TaskId && x.Status == false).Count;
                              if(newSubTaskCounter <= uncompletedSubTasks) {
                                    for(int i = 0; i < newSubTaskCounter; i++) {
                                          _subtaskDal.Delete(_subtaskDal.Get(x => x.TaskId == task.TaskId));
                                    }
                              } else {
                                    //TO DO 
                                    // not allow to change task session time
                                    task.SessionTime = oldTask.SessionTime;
                              }
                        } else {
                              SubTask subTask = _subtaskDal.Get(x => x.TaskId == task.TaskId);
                              if(subTask.Status == false) {
                                    // control subtask status 
                                    // if subtask status is false or null, then update subtask session time
                                    subTask.SessionTime = task.SessionTime;
                                    _subtaskDal.Update(subTask);

                              } else {
                                    //TO DO 
                                    //if subtasks status is true
                                    //not allow to change task session time
                                    task.SessionTime = oldTask.SessionTime;
                              }
                        }
                  }
                  _taskDal.Update(task);
            }
      }
}
