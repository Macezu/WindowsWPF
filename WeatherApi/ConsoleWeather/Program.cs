using System;

namespace ConsoleWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init everything then start the Console UI
            Location city = new Location();
            ValueParser parser = new ValueParser();
            WeatherStackApi weatherapi = new WeatherStackApi();
            CUI cui = new CUI(city,weatherapi, parser);
            cui.Start();
        
        }
    }
}
