using ClientApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;
        public WeatherForecastController(WeatherForecastService weatherForecastService) 
        {
            _weatherForecastService = weatherForecastService;
        }
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Ok(_weatherForecastService.GetInfo());
        }
    }
}
