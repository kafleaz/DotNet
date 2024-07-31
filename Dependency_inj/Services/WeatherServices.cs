using Microsoft.AspNetCore.Mvc;

namespace Dependency_inj.Services
{
    public class WeatherService : IWeatherService
    {
        public string GetForecast()
        {
            return "Today's weather is sunny!";
        }
    }

  
}
