using System;

namespace ConsoleWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            Location city = new Location();
            WeatherStackApi weatherapi = new WeatherStackApi();
            CUI cui = new CUI(city,weatherapi);
            cui.Start();
        
        }
    }
}
