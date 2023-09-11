using DsvSwapi.Domain.Models;
namespace DsvSwapi.Domain.Interfaces
{
    public interface IPlanet
    {
        Task<IEnumerable<Planet>> GetAllPlanet();
        Task<Planet> GetPlanet(string url);
    }
}
