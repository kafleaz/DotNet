using Microsoft.AspNetCore.Mvc;

namespace Dependency_inj.Services
{
        public interface IWeatherService
        {
            string GetForecast();
        }
}
