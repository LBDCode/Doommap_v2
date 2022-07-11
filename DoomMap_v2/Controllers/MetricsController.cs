using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsController : ControllerBase
    {

        private readonly IMetricsService _metricsService;


        public MetricsController(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMetrics()
        {
            var metrics = await _metricsService.GetAllMetrics();
            return Ok(metrics);

        }
      

        [HttpPost]
        [Route("viewmetrics")]
        public async Task<ActionResult> Post([FromBody] ViewBounds viewBounds)
        {

            var metrics = await _metricsService.GetMetricsInView(viewBounds);

            return Ok(metrics);
        }

    }
}