using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WeatherAPI.Dto;
using WeatherAPI.Models;
using WeatherAPI.Repositories;

namespace WeatherAPI.Services
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IWeatherSnapshotsRepository _repository;
        private readonly ICityRepository _cityRepository;

        public OpenWeatherService(
            HttpClient httpClient,
            IConfiguration configuration,
            IWeatherSnapshotsRepository repository,
            ICityRepository cityRepository)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _repository = repository;
            _cityRepository = cityRepository;
        }

        public async Task<WeatherSnapshots> GetAndStoreWeatherAsync(string city)
        {

            var theCity = await _cityRepository.GetByNameAsync(city);

            if (theCity == null)
            {
                theCity = await _cityRepository.AddAsync(new City
                {
                    Name = city
                });
            }

            var apiKey = _configuration["OpenWeather:ApiKey"];
            var baseUrl = _configuration["OpenWeather:BaseUrl"];

            WeatherSnapshots? snapshot = null;
            try { 
                var response = await _httpClient.GetAsync($"{baseUrl}?q={city}&units=metric&appid={apiKey}");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var weatherDto = JsonSerializer.Deserialize<OpenWeatherResponseDto>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                snapshot = new WeatherSnapshots
                {
                    City = weatherDto.Name,
                    Temperature = weatherDto.Main.Temp,
                    Humidity = weatherDto.Main.Humidity,
                    Description = weatherDto.Weather.First().Description,
                    WindSpeed = weatherDto.Wind.Speed,
                    Source = "OpenWeather",
                    CreatedAT = DateTime.UtcNow
                };

                await _repository.AddAsync(snapshot);

             }
             catch (HttpRequestException ex)
             {
                throw new Exception("Failed to fetch weather, check your API key or network.", ex);
             }
             return snapshot;
        }
    }
}
