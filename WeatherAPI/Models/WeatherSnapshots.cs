using System;

namespace WeatherAPI.Models
{
    public class WeatherSnapshots
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public DateTime CreatedAT { get; set; }     

    }
}
