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
      //To build services to reach User objects from mobile devices
      [RoutePrefix("api/users")]
      public class UsersController : BaseController {
            ApiResult result = new ApiResult();
            private readonly IUserService _userService;
            public UsersController(IUserService userService) => _userService = userService;

            [HttpGet, Route("")]
            public ApiResult GetUsers() {
                  try {
                        result.Result = true;
                        result.Data = _userService.GetUsers().Select(x => new UserViewModel { Email = x.Email, FullName = x.FullName, Password = x.Password, UserId = x.UserId, Username = x.Username }).ToList();
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpGet, Route("user/{id:int}")]
            public ApiResult GetUser(int id) {
                  try {
                        result.Result = true;
                        var user = _userService.GetUserwithDetails(id);

                        result.Data = new UserDetailViewModel { BeginWorkingTime = user.UserDetail.BeginWorkingTime, BirthDate = user.UserDetail.BirthDate, Email = user.Email, EndWorkingTime = user.UserDetail.EndWorkingTime, FullName = user.FullName, ImageURL = user.UserDetail.ImageURL, IsAdmin = user.UserDetail.IsAdmin, Password = user.Password, RegisterTime = user.UserDetail.RegisterTime, SleepingTime = user.UserDetail.SleepingTime, UserId = user.UserId, Username = user.Username, WakingTime = user.UserDetail.WakingTime };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpPost, Route("accountlogin")]
            public ApiResult LoginUser(LoginViewModel model) {
                  try {
                        result.Result = true;
                        var user = _userService.Login(model.Email, model.Password);
                        result.Data = new UserViewModel {UserId = user.UserId, Email = user.Email, Username = user.Username, FullName = user.FullName };
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ HttpPut, Route("edituser")]
            public ApiResult PutUser([FromBody]UserDetailViewModel model) {
                  try {
                        result.Result = true;
                        _userService.UpdateUser(new User { Email = model.Email, FullName = model.FullName, Password = model.Password, UserId = model.UserId, Username = model.Username, UserDetail = new UserDetail { BeginWorkingTime = model.BeginWorkingTime, UserId = model.UserId, BirthDate = model.BirthDate, EndWorkingTime = model.EndWorkingTime, ImageURL = model.ImageURL, IsAdmin = model.IsAdmin, SleepingTime = model.SleepingTime, WakingTime = model.WakingTime } });
                        result.Data = "User updated";
                        result.Message = "Success";

                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [ HttpPost, Route("adduser")]
            public ApiResult PostUser(UserDetailViewModel model) {
                  try {
                        result.Result = true;
                        _userService.AddUser(new User { Email = model.Email, FullName = model.FullName, Password = model.Password, Username = model.Username, UserDetail = new UserDetail { BeginWorkingTime = model.BeginWorkingTime, WakingTime = model.WakingTime, SleepingTime = model.SleepingTime, BirthDate = model.BirthDate, EndWorkingTime = model.EndWorkingTime, IsAdmin = model.IsAdmin, ImageURL = model.ImageURL } });
                        result.Data = "User added.";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }

            [HttpDelete, Route("deleteuser/{id:int}")]
            public ApiResult DeleteUser(int id) {
                  try {
                        result.Result = true;
                        _userService.DeleteUser(new User { UserId = id });
                        result.Data = "User deleted";
                        result.Message = "Success";
                  } catch(Exception ex) {
                        result.Result = false;
                        result.Message = $"Error : {ex.Message}";
                  }
                  return result;
            }
      }
}
