using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //User operations between web services and mobile
      public class UserManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/users/";

            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<UserDetailViewModel> Get(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}user/{userId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<UserDetailViewModel>(result.Data.ToString());
            }

            public async Task<IEnumerable<UserViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return (IEnumerable<UserViewModel>)JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(UserDetailViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "adduser", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<MobileResult> LoginAsync(LoginViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "accountlogin", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<MobileResult> PutAsync(UserDetailViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "edituser", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;      
            }

            public async Task<bool> DeleteAsync(UserViewModel model) {
                  var client = await GetClient();
                  var json = await client.DeleteAsync(Url + "deleteuser/" + model.UserId);

                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result.Result;
            }
      }
}
