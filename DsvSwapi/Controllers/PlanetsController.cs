using AutoMapper;
using DsvSwapi.Domain.Interfaces;
using DsvSwapi.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;

namespace DsvSwapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanet _planet;
        private readonly IMapper _mapper;
        public PlanetController(IMapper mapper, IPlanet planet) {

            _planet = planet;
            _mapper = mapper;
        }
        [Route("getAllPlanet")]
        [HttpGet]
       
        public async Task<IActionResult> Get()
        {
            var planets = await _planet.GetAllPlanet();
            var result = _mapper.Map<IEnumerable<Planet>>(planets);
            return Ok(result);
        }
       
        [HttpGet("getPlanet")]

        public async Task<IActionResult> Get([FromQuery] string url)
        {
            var people = await _planet.GetPlanet(Uri.UnescapeDataString(url));
            var result = _mapper.Map<Planet>(people);
            return Ok(result);
        }
    }
}
