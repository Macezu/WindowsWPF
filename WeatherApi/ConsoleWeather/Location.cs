using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWeather
{
    class Location
    {
        //Mahdollisuus maakunta,kaupunki jne tasolle

        // public string Maakunta
        public string CityName {get;set;}



        public void SetCity(string newCity) => CityName = newCity;

        public string GetCity() => CityName;

    }
}
