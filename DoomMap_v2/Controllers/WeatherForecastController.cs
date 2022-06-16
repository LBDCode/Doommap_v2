using DoomMap_v2.Models;
using Microsoft.AspNetCore.Mvc;



namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly DoomMapContext _context;



        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DoomMapContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IActionResult GetFires()
        {
            List<Fire> fires = new List<Fire>();
            fires = (from FireList in _context.Fires select FireList).ToList();
            return Ok(fires);
        }

    }
}