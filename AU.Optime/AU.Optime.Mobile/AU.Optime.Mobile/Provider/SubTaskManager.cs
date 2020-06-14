using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //SubTask operations between web services and mobile
      public class SubTaskManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/subtasks/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() =>
                  {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<IEnumerable<SubTaskViewModel>> GetSubTasksByTask(int id) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}/{id}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<SubTaskViewModel>>(result.Data.ToString());
            }

            public async Task<SubTaskViewModel> GetSubTask(int id) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}/subtask/{id}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<SubTaskViewModel>(result.Data.ToString());
            }

            public async Task<MobileResult> PutAsync(SubTaskViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "editsubtask", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }
      }
}
