using Dependency_inj.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_inj.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService; 
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public IActionResult Index()
        {
            string forecast = _weatherService.GetForecast(); 
            return View((object)forecast);
        }
    }
}


