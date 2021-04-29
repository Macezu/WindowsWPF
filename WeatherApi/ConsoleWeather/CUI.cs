using ConsoleWeather.Validators;
using FluentValidation.Results;
using System;


namespace ConsoleWeather
{
    class CUI
    {
        private Location location;
        private WeatherStackApi weatherApi;


        public CUI(Location aCity, WeatherStackApi aWeatherApi)
        {
            location = aCity;
            weatherApi = aWeatherApi;
        }
        
        public void Start()
        { 
            Start:
            while (true)
            {
                Console.WriteLine("Welcome. Write the name of the city for a forecast");
                string userInput = Console.ReadLine().Trim();
                location.SetCity(userInput);
       
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

            
            Console.WriteLine("Press 1 to see current weather\n2 for locations storical weather");
            string menuInput = Console.ReadLine();
            switch (menuInput)
            {
                case "1":
                    Console.WriteLine("Current Weather");
                    var responseObject = weatherApi.GetWeatherAsync(location.GetCity()).Result; 
                    if (responseObject is null) { goto Start; }
                    Console.WriteLine(responseObject);
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Locations Storical Weather");
                    weatherApi.GetStorical(location.GetCity());
                    break;
                default:
                    Console.WriteLine("Bad input");
                    break;
            }
                
                   
        }





    }
}
