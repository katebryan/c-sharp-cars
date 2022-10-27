using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace cSharpcars
{

    /// <summary>
    /// API Class
    ///
    /// functions
    /// -authentication
    /// -make api call
    /// </summary>
    public partial class API : IApi
    {
        public string getParking()
        {
            var result = getApiResponse(Endpoint.Carparks.ToString()).Result;
            //TODO map the json response to a model
            Console.WriteLine($"in func->> {result}");
            return result;
        }

        public async Task<string> getApiResponse(string endpoint)
        {
            var apiKey = "";
            var url = $"https://api.tfgm.com/odata/" + endpoint + "?$top=10";
            var result = CallUri(url,apiKey).Result;

            //Console.WriteLine($"Calling the URL--> {url}");

            if (result != null && result.IsSuccessStatusCode)
            {
                var apiContent = await result.Content.ReadAsStringAsync();
                return apiContent;
            }

            return null;
        }


        private async Task<HttpResponseMessage> CallUri(string url, string apiKey)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
            request.Headers.Add("Accept", "application/json");

            try
            {
                var client = new HttpClient();
                var response = await client.SendAsync(request);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling {url}", ex.InnerException);
                throw;
            }
        }

        public enum Endpoint
        {
            Metrolinks,
            Accidents,
            Carparks,
            Incidents,
            ScootLoops,
            TrafficSignals,
            VenueEvents
        }
    }
}

