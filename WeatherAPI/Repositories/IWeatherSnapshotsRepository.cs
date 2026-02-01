using WeatherAPI.Models;

namespace WeatherAPI.Repositories
{
    public interface IWeatherSnapshotsRepository
    {
        Task AddAsync(WeatherSnapshots snapshot);
        List<WeatherSnapshots> GetWeatherSnapshots();
        public WeatherSnapshots? GetLatestByCity(string city);
    }
}
