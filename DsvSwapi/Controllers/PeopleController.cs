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
    public class PeopleController : ControllerBase
    {
        private readonly IPeople _people;
        private readonly IMapper _mapper;
        public PeopleController(IMapper mapper,IPeople people) {

            _people = people;
            _mapper = mapper;
        }
        [Route("getAllPeople")]
        [HttpGet]
       
        public async Task<IActionResult> Get()
        {
            var peoples = await _people.GetAllPeople();
            var result = _mapper.Map<IEnumerable<People>>(peoples);
            return Ok(result);
        }
       
        [HttpGet("getPeople")]

        public async Task<IActionResult> Get([FromQuery] string url)
        {
            var people = await _people.GetPeople(Uri.UnescapeDataString(url));
            var result = _mapper.Map<People>(people);
            return Ok(result);
        }
    }
}
