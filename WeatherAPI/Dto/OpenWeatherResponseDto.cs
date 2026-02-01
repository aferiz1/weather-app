namespace WeatherAPI.Dto
{
    public class OpenWeatherResponseDto
    {
        public string Name { get; set; }
        public MainDto Main { get; set; }
        public List<WeatherDto> Weather { get; set; }
        public WindDto Wind { get; set; }
    }

    public class MainDto
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherDto
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class WindDto
    {
        public double Speed { get; set; }
    }

}
