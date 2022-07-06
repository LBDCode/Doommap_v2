using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiresController : ControllerBase
    {

        private readonly IFiresService _firesService;


        public FiresController(IFiresService firesService)
        {
            _firesService = firesService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFires()
        {
            var fires = await _firesService.GetAllFires();
            return Ok(fires);


        }


        [HttpPost]
        [Route("viewfires")]
        public async Task<ActionResult> Post([FromBody] ViewBounds viewBounds)
        {
            Debug.WriteLine("in controller");

            var fires = await _firesService.GetFiresInView(viewBounds);

            return Ok(fires);
        }

    }
}