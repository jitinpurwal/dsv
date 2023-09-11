using DsvSwapi.Domain.Models;
namespace DsvSwapi.Domain.Interfaces
{
    public interface IFilm
    {
        Task<IEnumerable<Film>> GetAllFilm();
        Task<Film> GetFilm(string url);
    }
}
