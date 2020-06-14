using AU.Optime.Mobile.Models;
using AU.Optime.Mobile.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AU.Optime.Mobile.Provider {
      //Schedule operations between web services and mobile
      public class ScheduleManager {
            private readonly string Url = "http://192.168.0.13/GondorApp/api/schedules/";
            HttpClient client = new HttpClient();
            private Task<HttpClient> GetClient() {
                  return Task.Run(() =>
                  {
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        return client;
                  });
            }

            public async Task<IEnumerable<ScheduleViewModel>> GetAllScheduleByUser(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}" + $"/{userId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ScheduleViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<ScheduleViewModel>> GetDailySchedule(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}/daily/{userId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ScheduleViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<ScheduleViewModel>> GetWeeklySchedule(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}/weekly/{userId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ScheduleViewModel>>(result.Data.ToString());
            }

            public async Task<IEnumerable<ScheduleViewModel>> GetMonthlySchedule(int userId) {
                  client = await GetClient();
                  var json = await client.GetStringAsync($"{Url}/monthly/{userId}");
                  var result = JsonConvert.DeserializeObject<MobileResult>(json);
                  return JsonConvert.DeserializeObject<IEnumerable<ScheduleViewModel>>(result.Data.ToString());
            }
      }
}
