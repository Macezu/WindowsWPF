using Newtonsoft.Json.Linq;
using System;

namespace ConsoleWeather
{
    public class ValueParser
    {
        public Location GetValues(JObject jObject, Location location)
        {
            // Parse needed values to form a complete location
            try
            {
                location.Country = (string)jObject["location"]["country"];
                location.Name = (string)jObject["location"]["name"];
                location.Temperature = (int)jObject["current"]["temperature"];
                location.FeelsLike = (int)jObject["current"]["feelslike"];
                location.Description = (string)jObject["current"]["weather_descriptions"][0];
                location.FeelsLike = (int)jObject["current"]["feelslike"];
                location.Wind = (string)jObject["current"]["wind_speed"];
                return location;
            }
            catch (Exception e) { 
                Console.WriteLine($"Could not parse incoming Json, {e}");
                return location;
            }
            
        }
    }
}