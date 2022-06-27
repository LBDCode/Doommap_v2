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
            Debug.WriteLine("in droughts controller");

            var droughts = await _droughtsService.GetAllDroughts();

            if (droughts.Any())
            {
                return Ok(droughts);
            } else
            {
                return NotFound();

            }

        }

        //[HttpGet("{objectid}", Name = "GetByFireID")]
        //public async Task<IActionResult> GetFireByID(string objectid)
        //{
        //    var Gid = int.Parse(objectid);
        //    var fire = await _firesService.GetFireByID(Gid);

        //    if (fire.Any())
        //    {
        //        return Ok(fire);
        //    } else
        //    {
        //        return NotFound();
        //    }
        //}


        //[HttpPost]
        //[Route("viewfires")]
        //public async Task<ActionResult> Post([FromBody] ViewBounds viewBounds)
        //{
        //    Debug.WriteLine("in controller");

        //    var fires = await _firesService.GetFiresInView(viewBounds);

        //    return Ok(fires);
        //}

    }
}