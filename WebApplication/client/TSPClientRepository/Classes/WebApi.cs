using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TSPClientRepository.Models;

namespace TSPClientRepository.Classes
{
    public static class WebApi
    {
        public static HttpClient http = ConnectionInitial.GetServer();


        public static async Task<String> PostMarkers(List<City> cities)
        {
            var jsonObj = JsonConvert.SerializeObject(cities);
            var response = await http.PostAsync("api/route?version=1.0", new StringContent(jsonObj, Encoding.UTF8, "text/json"));
            if(response.IsSuccessStatusCode)
            {
                string jsonMessage;
                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    jsonMessage = new StreamReader(responseStream).ReadToEnd();
                }
                jsonMessage = jsonMessage.Replace("\"", "");
                UserSettings.Instance().token = jsonMessage;
                UserSettings.Instance().latestUse = DateTime.Now;
                return jsonMessage;
            }
            else
            {
                return ("");
            }
        }
        public static async Task<List<City>> GetMarkers(string token)
        {
            var response = await http.GetAsync("api/route/" + token+"?version=1.0");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                List<City> cities = JsonConvert.DeserializeObject<List<City>>(result);
                return cities;
            }
            else
            {
                return new List<City>();
            }
        }
    }
}