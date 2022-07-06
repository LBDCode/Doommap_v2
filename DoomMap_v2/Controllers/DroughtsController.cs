using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroughtsController : ControllerBase
    {

        private readonly IDroughtsService _droughtsService;


        public DroughtsController(IDroughtsService droughtsService)
        {
            _droughtsService = droughtsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDroughts()
        {

            var droughts = await _droughtsService.GetAllDroughts();
            return Ok(droughts);


        }


        [HttpPost]
        [Route("viewdroughts")]
        public async Task<ActionResult> Post([FromBody] ViewBounds viewBounds)
        {
            Debug.WriteLine("in controller");

            var droughts = await _droughtsService.GetDroughtsInView(viewBounds);

            return Ok(droughts);
        }

    }
}