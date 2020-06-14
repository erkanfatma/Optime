using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //Project operations between web services and mobile
      public class ProjectManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/projects/";

            HttpClient client = new HttpClient();
            
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<IEnumerable<ProjectViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ProjectViewModel>>(result.Data.ToString());
            }

            public async Task<ProjectDetailViewModel> Get(int projectId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}project/{projectId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<ProjectDetailViewModel>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(ProjectDetailViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "addproject", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<MobileResult> PutAsync(ProjectDetailViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "editpproject", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<bool> DeleteAsync(ProjectViewModel model) {
                  var client = await GetClient();
                  var json = await client.DeleteAsync(Url + "deleteproject/" + model.ProjectId);
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result.Result;
            }

      }
}
