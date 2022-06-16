using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;



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

            if (fires.Any())
            {
                return Ok(fires);
            } else
            {
                return NotFound();

            }

        }

        [HttpGet(Name = "GetFireById")]
        public async Task<IActionResult> GetFireByID([FromBody] string fireID)
        {
            var Gid = int.Parse(fireID);
            var fire = await _firesService.GetFireByID(Gid);

            if (fire.Any())
            {
                return Ok(fire);
            } else
            {
                return NotFound();
            }
        }

    }
}