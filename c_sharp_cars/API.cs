using System;
using System.Web;
using Newtonsoft.Json.Linq;

namespace c_sharp_cars
{
    public class API
    {
        private string _apiKey;

        public API(string apiKey)
        {
            _apiKey = apiKey;
        }

        static async Task<JObject> MakeRequest(string apiKey, string endpoint, string queryString = "")
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

            // Request address
            var uri = "https://api.tfgm.com/odata/" + endpoint + "?" + queryString;

            var response = await client.GetAsync(uri);
            string strResponse = await response.Content.ReadAsStringAsync();
            return JObject.Parse(strResponse);
        }

        public async Task<JObject> GetAllCarParks() {
            return await API.MakeRequest(_apiKey, "Carparks");
        }
    }
}

