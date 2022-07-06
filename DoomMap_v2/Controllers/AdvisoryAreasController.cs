using DoomMap_v2.Models;
using DoomMap_v2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoomMap_v2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvisoryAreasController : ControllerBase
    {

        private readonly IAdvisoryAreasService _advisoryAreasService;


        public AdvisoryAreasController(IAdvisoryAreasService advisoryAreasService)
        {
            _advisoryAreasService = advisoryAreasService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAreass()
        {

            var areas = await _advisoryAreasService.GetAllAreas();

            return Ok(areas);


        }



    }
}