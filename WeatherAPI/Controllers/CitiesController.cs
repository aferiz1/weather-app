using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Repositories;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _cityRepository.GetAllAsync());
        }
    }

}
