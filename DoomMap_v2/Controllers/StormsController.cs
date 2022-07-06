using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StormsController : ControllerBase
    {

        private readonly IStormsService _stormsService;


        public StormsController(IStormsService stormsService)
        {
            _stormsService = stormsService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllStorms()
        {

            var storms = await _stormsService.GetAllStorms();

            if (storms.Any())
            {
                return Ok(storms);
            } else
            {
                return NotFound();

            }

        }

        

    }
}