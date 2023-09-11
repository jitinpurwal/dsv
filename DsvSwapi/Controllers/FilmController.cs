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
    public class FilmController : ControllerBase
    {
        private readonly IFilm _Film;
        private readonly IMapper _mapper;
        public FilmController(IMapper mapper,IFilm Film) {

            _Film = Film;
            _mapper = mapper;
        }
        [Route("getAllFilm")]
        [HttpGet]
       
        public async Task<IActionResult> Get()
        {
            var Films = await _Film.GetAllFilm();
            var result = _mapper.Map<IEnumerable<Film>>(Films);
            return Ok(result);
        }
       
        [HttpGet("getFilm")]

        public async Task<IActionResult> Get([FromQuery] string url)
        {
            var Film = await _Film.GetFilm(Uri.UnescapeDataString(url));
            var result = _mapper.Map<Film>(Film);
            return Ok(result);
        }
    }
}
