using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StormTracksController : ControllerBase
    {

        private readonly IStormTracksService _stormTracksService;


        public StormTracksController(IStormTracksService stormTracksService)
        {
            _stormTracksService = stormTracksService;
        }



        [HttpGet("{type}", Name = "GetTrackByComponent")]
        public async Task<IActionResult> Get(string type)
        {

            if (type == "line")
            {
                var stormTrackLines = await _stormTracksService.GetAllStormTrackLines();
                return Ok(stormTrackLines);


            }
            else if (type == "pgn")
            {

                var stormTrackPolygons = await _stormTracksService.GetAllStormTrackPolygons();
                return Ok(stormTrackPolygons);

            }
            else if (type == "pts")
            {

                var stormTrackPoints = await _stormTracksService.GetAllStormTrackPoints();
                return Ok(stormTrackPoints);

            }
            else
            {
                return Ok();
            }

        }
    }
}