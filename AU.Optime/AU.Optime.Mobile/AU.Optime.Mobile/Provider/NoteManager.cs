using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AU.Optime.Mobile.Provider {
      //Note operations between web services and mobile
      public class NoteManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/notes/";
            //"http://192.168.0.13/AU.Optime.WebApi/api/notes/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() => {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<NoteViewModel> Get(int noteId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}note/{noteId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<NoteViewModel>(result.Data.ToString());
            }

            public async Task<IEnumerable<NoteViewModel>> GetAll() {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return (IEnumerable<NoteViewModel>)JsonConvert.DeserializeObject<IEnumerable<NoteViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<NoteViewModel>> GetNotesByUserId(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}" + "getnotesbyuser/" + userId);
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return (IEnumerable<NoteViewModel>)JsonConvert.DeserializeObject<IEnumerable<NoteViewModel>>(result.Data.ToString());
            }

            public async Task<MobileResult> PostAsync(NoteViewModel model) {
                  var client = await GetClient();
                  var json = await client.PostAsync(Url + "addnote", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;
                  //TO DO : to return NoteViewModel in method add below statement
                  //return JsonConvert.DeserializeObject<NoteViewModel>(result.Data.ToString());
            }

            public async Task<MobileResult> PutAsync(NoteViewModel model) {
                  var client = await GetClient();
                  var json = await client.PutAsync(Url + "editnote", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result;

                  //TO DO : to return NoteViewModel in method add below statement
                  //return JsonConvert.DeserializeObject<NoteViewModel>(result.Data.ToString());       
            }

            public async Task<bool> DeleteAsync(NoteViewModel model) {
                  var client = await GetClient();
                  var json = await client.DeleteAsync(Url + "deletenote/" + model.NoteId);

                  var result = JsonConvert.DeserializeObject<MobileResult>(await json.Content.ReadAsStringAsync());
                  return result.Result;
                  //return JsonConvert.DeserializeObject<bool>(result.Result);
            }

      }
}
