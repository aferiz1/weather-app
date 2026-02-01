using WeatherAPI.Models;

namespace WeatherAPI.Repositories
{
    public class WeatherSnapshotsRepository : IWeatherSnapshotsRepository
    {
        private readonly ApplicationDbContext _context;
        public WeatherSnapshotsRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task AddAsync(WeatherSnapshots snapshot)
        {
            _context.WeatherSnapshots.Add(snapshot);
            await _context.SaveChangesAsync();
        }
        public List<WeatherSnapshots> GetWeatherSnapshots()
        {
            return _context.WeatherSnapshots.ToList();
        }
        public WeatherSnapshots? GetLatestByCity(string city)
        {
            return _context.WeatherSnapshots
                .Where(x => x.City == city)
                .OrderByDescending(x => x.CreatedAT)
                .FirstOrDefault();
        }

    }
}
