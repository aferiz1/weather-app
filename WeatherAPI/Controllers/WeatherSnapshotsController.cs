using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Repositories;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherSnapshotsController : ControllerBase
    {
        private readonly IWeatherSnapshotsRepository _weatherSnapshotsRepository;
        private readonly IWeatherService _weatherService;
        public WeatherSnapshotsController(IWeatherSnapshotsRepository weatherSnapshotsRepository, IWeatherService weatherService)
        {
            _weatherSnapshotsRepository = weatherSnapshotsRepository;  
            _weatherService = weatherService;
        }

        [HttpGet("GetWeatherSnapshots")]
        public IActionResult GetWeatherSnapshots()
        {
            var weatherSnapshots = _weatherSnapshotsRepository.GetWeatherSnapshots();
            return Ok(weatherSnapshots);
        }

        [HttpPost("fetch")]
        public async Task<IActionResult> FetchWeather(string city)
        {
            var result = await _weatherService.GetAndStoreWeatherAsync(city);
            return Ok(result);
        }

        [HttpGet("current")]
        public IActionResult GetCurrent(string city)
        {
            var weather = _weatherSnapshotsRepository.GetLatestByCity(city);
            return Ok(weather);
        }

    }
}
