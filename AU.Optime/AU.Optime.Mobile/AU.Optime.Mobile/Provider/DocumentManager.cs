using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //Documentation operations between web services and mobile
      public class DocumentManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/docs/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() =>
                  {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<DocumentationViewModel> Get(int docId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}doc/{docId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<DocumentationViewModel>(result.Data.ToString());
            }

            public async Task<IEnumerable<DocumentationViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<DocumentationViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<DocumentationViewModel>> GetDocsByRelation(int id, bool isProject) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}" + "docsbyrelation/" + id + "/" + isProject);
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<DocumentationViewModel>>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(DocumentationViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "adddoc", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<MobileResult> PutAsync(DocumentationViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "editdoc", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
            }

            public async Task<bool> DeleteAsync(DocumentationViewModel model) {
                  var client = await GetClient();
                  var json = await client.DeleteAsync(Url + "deletenote/" + model.DocumentationId);

                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result.Result;
            }
      }
}
