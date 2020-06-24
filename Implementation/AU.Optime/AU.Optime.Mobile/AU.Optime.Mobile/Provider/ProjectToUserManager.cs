using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //ProjectToUser operations between web services and mobile
      public class ProjectToUserManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/p2u/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<IEnumerable<ProjectToUserViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ProjectToUserViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<ProjectToUserViewModel>> GetProjectsByUser(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}projects/{userId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ProjectToUserViewModel>>(result.Data.ToString());
            }
            public async Task<IEnumerable<ProjectToUserViewModel>> GetUsersByProject(int projectId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}users/{projectId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ProjectToUserViewModel>>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(ProjectToUserViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "addp2u", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<MobileResult> PutAsync(ProjectToUserViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "editp2u", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;      
            }
      }
}
