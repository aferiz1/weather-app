namespace WeatherAPI.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByNameAsync(string name);
        Task<City> AddAsync(City city);
    }
}
