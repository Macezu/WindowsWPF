using ConsoleWeather.Validators;
using FluentValidation.Results;
using Newtonsoft.Json.Linq;
using System;


namespace ConsoleWeather
{
    class CUI
    {
        private Location location;
        private WeatherStackApi weatherApi;
        private ValueParser parser;


        public CUI(Location aCity, WeatherStackApi aWeatherApi, ValueParser aParser)
        {
            location = aCity;
            weatherApi = aWeatherApi;
            parser = aParser;
        }
        
        public void Start()
        { 
            //The start of the Console UI, that restarts the search process
            Start:
            while (true)
            {
                Console.WriteLine("Welcome. Write the name of the city for a forecast");
                string userInput = Console.ReadLine().Trim();
                location.setCity(userInput);
       
                //Validate city name
                CityValidator validator = new CityValidator();
                var results = validator.Validate(location);

                if (results.IsValid == false)
                {
                    foreach (ValidationFailure failure in results.Errors)
                    {
                        Console.WriteLine(failure.ErrorMessage);
                    }
                } else { break; }

            }

            
            // Menu that defines what kind of forecast the user wants
            Console.WriteLine("Press 1 to see current weather\n2 for locations storical weather");
            string menuInput = Console.ReadLine();
            switch (menuInput)
            {
                case "1":
                    Console.WriteLine("Current Weather");
                    var response = weatherApi.GetWeatherAsync(location.GetCity()).Result;
                    JObject jObject = JObject.Parse(response);
                    if (jObject is null ) { goto Start; }
                    if (jObject.ContainsKey("success"))
                    {
                        Console.WriteLine("Could not find city\n");
                        goto Start;
                    }
                    location = parser.GetValues(jObject, location);
                    Console.WriteLine(location);
                    Console.ReadKey();
                    goto Start;
                case "2":
                    Console.WriteLine("Locations storical weather");
                    Console.WriteLine("Not implemented yet\n");
                    goto Start;
                default:
                    Console.WriteLine("Bad input");
                    goto Start;
            }
                
                   
        }





    }
}
