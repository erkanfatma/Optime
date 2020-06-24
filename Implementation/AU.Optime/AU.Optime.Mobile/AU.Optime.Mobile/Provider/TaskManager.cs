using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //Task operations between web services and mobile
      public class TaskManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/tasks/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() =>
                  {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<TaskDetailViewModel> Get(int taskId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}task/{taskId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<TaskDetailViewModel>(result.Data.ToString());
            }
            public async Task<IEnumerable<TaskViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<TaskViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<TaskViewModel>> GetTasksById(int id, string type) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}" + "tasksbyid/" + id + "/" + type);
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<TaskViewModel>>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(TaskDetailViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "addtask", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<MobileResult> PutAsync(TaskDetailViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "edittask", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }
            public async Task<bool> DeleteAsync(TaskViewModel model) {
                  var client = await GetClient();
                  var json = await client.DeleteAsync(Url + "deletetask/" + model.TaskId);

                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result.Result;
            }
      }
}
