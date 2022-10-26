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
        //TODO pass endpoints and query as params to this function
        public async Task<string> getApiResponse()
        {
            var apiKey = "FILL THIS WITH YOUR API KEY - run test";
            var endpoint = Endpoint.Carparks;

            var url = $"https://api.tfgm.com/odata/" + endpoint + "?$top=10";



            var result = CallUri(url,apiKey).Result;

            Console.WriteLine($"Calling the API --> {url}");

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

