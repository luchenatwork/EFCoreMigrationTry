using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreMigrationTry.DataAccess.DbContexts;
using EFCoreMigrationTry.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreMigrationTry.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastDbContext _weatherForecastDbContext;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            WeatherForecastDbContext weatherForecastDbContext)
        {
            _logger = logger;
            _weatherForecastDbContext = weatherForecastDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            var weatherForecasts = await _weatherForecastDbContext.WeatherForecasts.ToListAsync();

            return Ok(weatherForecasts);
        }
    }
}
