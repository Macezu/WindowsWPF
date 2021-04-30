using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ConsoleWeather
{
    class WeatherStackApi
    {
        private string _baseUrl = "http://api.weatherstack.com/";
        private string _apiKey = Environment.GetEnvironmentVariable("APIKEY");

        // 3461211e53c1a94f6401ff5773967c52
        public async Task<string> GetWeatherAsync(string city)
        {

            try
            {
                // Get a response from WeatherStackApi
                HttpClient client = new HttpClient { BaseAddress = new Uri(_baseUrl) };
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"current{_apiKey}&query={city}").Result;
                return (response.IsSuccessStatusCode) ? await response.Content.ReadAsStringAsync() : throw new HttpRequestException(response.ReasonPhrase);
                
                //Handle errors
            } catch (ArgumentException e ){
                Console.WriteLine($"Invalid request{e.Message}\n");
                return "{success:false}";
            } catch (AggregateException e)
            {
                Console.WriteLine($"An error occured {e.Message}\n");
                return "{success:false}";
            } catch (UriFormatException e)
            {
                Console.WriteLine($"Bad URI, {e.Message}\n");
                return "{success:false}";
            }
            

        }

        public void GetStorical(string city)
        {
            throw new NotImplementedException();
        }
    }
}
