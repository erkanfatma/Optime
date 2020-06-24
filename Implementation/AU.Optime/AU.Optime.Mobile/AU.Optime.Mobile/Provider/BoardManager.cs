using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //Board operations between web services and mobile
      public class BoardManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/boards/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<BoardViewModel> Get(int boardId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}board/{boardId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<BoardViewModel>(result.Data.ToString());
            }

            public async Task<IEnumerable<BoardViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return (IEnumerable<BoardViewModel>)JsonConvert.DeserializeObject<IEnumerable<BoardViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<BoardViewModel>> GetBoardsByProject(int projectId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}getboardsbyproject/{projectId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<BoardViewModel>>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(BoardViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "addboard", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result; 
            }

            public async Task<MobileResult> PutAsync(BoardViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "editboard", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;     
            }
            public async Task<bool> DeleteAsync(BoardViewModel model) {
                  var client = await GetClient();
                  var json = await client.DeleteAsync(Url + "deleteboard/" + model.BoardId);
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result.Result;
            }
      }
}
