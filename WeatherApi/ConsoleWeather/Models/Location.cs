
namespace ConsoleWeather
{
 
    // The class that holds the basic data of the city
    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Temperature { get; set; }
        public int FeelsLike { get; set; }
        public string Wind { get; set; }
        public string Description { get; set; }
 

        public void setCity(string value) => Name = value;

        public string GetCity() => Name;

        public override string ToString()
        {
            return $"Found {Name} in {Country}.\nDescription: {Description}\nWind speed:{Wind} M/S\nTemperature {Temperature}C, feels like {FeelsLike}C\n";
        }
    }

    

  
}
