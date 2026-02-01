using WeatherAPI.Repositories;

namespace WeatherAPI.Services
{
    public class WeatherBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public WeatherBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var cityRepo = scope.ServiceProvider.GetRequiredService<ICityRepository>();
                var weatherService = scope.ServiceProvider.GetRequiredService<IWeatherService>();

                var cities = await cityRepo.GetAllAsync();

                foreach (var city in cities)
                {
                    await weatherService.GetAndStoreWeatherAsync(city.Name);
                }

                await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }
    }
}
