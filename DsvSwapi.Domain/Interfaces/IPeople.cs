using DsvSwapi.Domain.Models;
namespace DsvSwapi.Domain.Interfaces
{
    public interface IPeople
    {
        Task<IEnumerable<People>> GetAllPeople();
        Task<People> GetPeople(string url);
    }
}
