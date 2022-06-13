using Microsoft.AspNetCore.Mvc;
using WebAPIOficina.Data.Context;
using WebAPIOficina.Domain.Models;

namespace WebAPIOficina.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        protected readonly WebAPIOficinaDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WebAPIOficinaDbContext context)
        {
            _logger = logger;
            _context = context;

            var clientes = _context.Set<Cliente>().ToList();
            var clienteVeiculo = _context.Set<ClienteVeiculo>().ToList();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}