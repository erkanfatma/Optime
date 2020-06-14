using AU.Optime.BLL.Abstract;
using AU.Optime.BLL.Concrete;
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
      //To build services to reach ProjectToUser objects from mobile devices
      [RoutePrefix("api/p2u")]
      public class ProjectToUsersController : ApiController {
            ApiResult result = new ApiResult();
            private readonly IProjectToUserService _p2uService;
            private readonly IProjectService _projectService;
            private readonly IUserService _userService;

            public ProjectToUsersController(IProjectToUserService p2uService, IProjectService projectService, IUserService userService) {
                  _p2uService = p2uService;
                  _projectService = projectService;
                  _userService = userService;
            }

            [HttpGet, Route("")]
            public ApiResult GetProjectToUsers() {
                  try {
                        List<ProjectToUserViewModel> p2u = new List<ProjectToUserViewModel>();
                        result.Result = true;
                        List<ProjectToUserViewModel> p2uModel = _p2uService.GetProjectToUsers().Select(x => new ProjectToUserViewModel { UserId = x.UserId, ProjectId = x.ProjectId, IsManager = x.IsManager }).ToList();
                        foreach(var item in p2uModel) {
                              User user = _userService.GetUser(item.UserId);
                              Project project = _projectService.GetProject(item.ProjectId);
                              p2u.Add(new ProjectToUserViewModel { ProjectId = project.ProjectId, Description = project.Description, Title = project.Name, UserId = user.UserId, Email = user.Email, FullName = user.Email, IsManager = item.IsManager });
                        }

                        //This code gives error because of lazy loading. 
                        //List<ProjectToUserViewModel> p2u = _p2uService.GetProjectToUsers().Select(x => new ProjectToUserViewModel { Description = x.Project.Description, Email = x.User.Email, FullName = x.User.FullName, IsManager = x.IsManager, ProjectId = x.ProjectId, Title = x.Project.Name, UserId = x.UserId }).ToList();

                        result.Data = p2u;
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("projects/{userId:int}")]
            public ApiResult GetProjectsByUser(int userId) {
                  try {
                        List<ProjectToUserViewModel> projects = new List<ProjectToUserViewModel>();
                        var p2uProjects = _p2uService.GetProjectsByUserId(userId).Select(x => new ProjectToUserViewModel { UserId = x.UserId, ProjectId = x.ProjectId, IsManager = x.IsManager });
                        foreach(var item in p2uProjects) {
                              Project project = _projectService.GetProject(item.ProjectId);
                              projects.Add(new ProjectToUserViewModel { Description = project.Description, ProjectId = project.ProjectId, IsManager = item.IsManager, Title = project.Name, UserId = item.UserId});
                        }
                        result.Result = true;
                        result.Data = projects; 
                        /* _p2uService.GetProjectsByUserId(userId).Select(x => new ProjectToUserViewModel { Description = x.Project.Description, ProjectId = x.ProjectId, Title = x.Project.Name, UserId = x.UserId }).ToList(); */
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("users/{projectId:int}")]
            public ApiResult GetUsersByProject(int projectId) {
                  try {
                        List<ProjectToUserViewModel> users = new List<ProjectToUserViewModel>();
                        var p2uUsers = _p2uService.GetUsersByProjectId(projectId).Select(x => new ProjectToUserViewModel { UserId = x.UserId, ProjectId = x.ProjectId, IsManager = x.IsManager});
                        foreach(var item in p2uUsers) {
                              User user = _userService.GetUser(item.UserId);
                              users.Add(new ProjectToUserViewModel { UserId = user.UserId, Email = user.Email, FullName = user.FullName, IsManager = item.IsManager, ProjectId = item.ProjectId });
                        }
                        result.Result = true;
                        result.Data = users;
                        /*_p2uService.GetUsersByProjectId(projectId).Select(x => new ProjectToUserViewModel { Email = x.User.Email, FullName = x.User.FullName, IsManager = x.IsManager, ProjectId = x.ProjectId, Title = x.Project.Name, UserId = x.UserId }).ToList();*/
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPut, Route("editp2u")]
            public ApiResult PutProjectToUsers([FromBody]ProjectToUserViewModel model) {
                  try {
                        result.Result = true;
                        _p2uService.UpdateProjectToUser(new ProjectToUser { IsManager = model.IsManager, ProjectId = model.ProjectId, UserId = model.UserId });
                        result.Data = "Users updated.";
                        result.Message = "Success";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ResponseType(typeof(ApiResult)), HttpPost, Route("addp2u")]
            public ApiResult PostProjectToUsers([FromBody]ProjectToUserViewModel model) {

                  try {
                        result.Result = true;
                        _p2uService.AddProjectToUser(new ProjectToUser { IsManager = model.IsManager, ProjectId = model.ProjectId, UserId = model.UserId });
                        result.Data = "Users added.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            //TO DO: Remember whether user deleted for wrong operations

            //[ResponseType(typeof(ProjectToUserViewModel)), HttpDelete, Route("deletep2u/{id:int}")]
            //public IHttpActionResult DeleteProjectToUser(int id)
            //{

            //}
      }
}
