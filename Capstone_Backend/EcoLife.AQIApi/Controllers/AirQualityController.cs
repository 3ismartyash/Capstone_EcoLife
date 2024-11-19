using EcoLife.AQIApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoLife.AQIApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualityController : ControllerBase
    {
        private readonly IAirQualityService _airQualityService;

        public AirQualityController(IAirQualityService airQualityService)
        {
            _airQualityService = airQualityService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetAirQuality(string city)
        {
            var airQualityData = await _airQualityService.GetAirQualityAsync(city);
            return Ok(airQualityData);
        }
    }
}
