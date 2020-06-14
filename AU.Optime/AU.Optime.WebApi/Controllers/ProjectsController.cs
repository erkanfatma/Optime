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
      //To build services to reach Project objects from mobile devices
      [RoutePrefix("api/projects")]
      public class ProjectsController : BaseController {
            ApiResult result = new ApiResult();
            private readonly IProjectService _projectService;
            private readonly IProjectToUserService _p2uService;
            public ProjectsController(IProjectService projectService, IProjectToUserService p2uService) { 
                  _projectService = projectService;
                  _p2uService = p2uService;
            }

            // GET: api/Notes
            [HttpGet, Route("")]
            public ApiResult GetProjects() {
                  try {
                        result.Result = true;
                        var projects = _projectService.GetProjects().Select(c => new ProjectViewModel { Description = c.Description, Name = c.Name, ProjectId = c.ProjectId, }).ToList();
                        result.Data = projects;
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }


            // GET: api/Notes/5
            [ResponseType(typeof(ApiResult)), HttpGet, Route("project/{id:int}")]
            public ApiResult GetProject(int id) {
                  try {
                        result.Result = true;
                        var project = _projectService.GetProject(id);
                        result.Data = new ProjectDetailViewModel { Description = project.Description, Name = project.Name, ProjectId = project.ProjectId, RegisterTime = project.RegisterTime };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            // PUT: api/Notes/5
            [ResponseType(typeof(ApiResult)), HttpPut, Route("editproject")]
            public ApiResult PutProject([FromBody]ProjectDetailViewModel model) {
                  try {
                        result.Result = true;
                        _projectService.UpdateProject(new Project { Description = model.Description, Name = model.Name, ProjectId = model.ProjectId, RegisterTime = model.RegisterTime });
                        result.Data = "Project updated.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            // POST: api/Notes
            [ResponseType(typeof(ApiResult)), HttpPost, Route("addproject")]
            public ApiResult PostProject(ProjectDetailViewModel model) {
                  try {
                        Project project = new Project { Description = model.Description, Name = model.Name };
                        result.Result = true;
                        _projectService.AddProject(project);
                        _p2uService.AddProjectToUser(new ProjectToUser { Project = project, UserId = model.UserId });
                        result.Data = "Project added.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            // DELETE: api/Notes/5
            [ResponseType(typeof(ApiResult)), HttpDelete, Route("deleteproject/{id:int}")]
            public ApiResult DeleteProject(int id) {
                  try {
                        result.Result = true;
                        _projectService.DeleteProject(new Project { ProjectId = id });
                        result.Data = "Project deleted";
                        result.Message = "Success";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }
      }
}
