using AutoMapper;
using DsvSwapi.Domain.Models;

namespace DsvSwapi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PeopleDTO, People>().ReverseMap();
            CreateMap <PlanetDTO, Planet>().ReverseMap();
            CreateMap<FilmDTO, FilmDTO>().ReverseMap();
        }
    }
}
