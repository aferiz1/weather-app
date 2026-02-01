using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public interface IWeatherService
    {
        Task<WeatherSnapshots> GetAndStoreWeatherAsync(string city);
        
      
    }
}
