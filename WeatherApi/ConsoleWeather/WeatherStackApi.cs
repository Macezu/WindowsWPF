using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleWeather
{
    class WeatherStackApi
    {
        private string _baseUrl = "http://api.weatherstack.com/";
        private string _apiKey = "?access_key=3461211e53c1a94f6401ff5773967c52";

        // 3461211e53c1a94f6401ff5773967c52
        public async Task<string> GetWeatherAsync(string city)
        {

            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUrl) };
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"current{_apiKey}&query={city}").Result;
                return  (response.IsSuccessStatusCode) ? await response.Content.ReadAsStringAsync() : throw new HttpRequestException(response.ReasonPhrase);
             

            } catch (ArgumentException e ){
                Console.WriteLine($"Arguments given where not valid {e.Message}\n");
                return null;
            } catch (AggregateException e)
            {
                Console.WriteLine($"An error occured {e.Message}\n");
                return null;
            }
            

        }

        public void GetStorical(string city)
        {
            throw new NotImplementedException();
        }
    }
}
