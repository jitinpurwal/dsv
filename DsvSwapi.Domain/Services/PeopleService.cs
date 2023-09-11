using DsvSwapi.Domain.Helper;
using DsvSwapi.Domain.Interfaces;
using DsvSwapi.Domain.Models;
using DsvSwapi.Domain.Response;
using Newtonsoft.Json;

namespace DsvSwapi.Domain.Services
{
    public class PeopleService : IPeople
    {
        public async Task<IEnumerable<People>> GetAllPeople () {

            using var httpClient = new HttpClient();
            var apiUrl = Constants.BaseURL + "people/";
            var response = await httpClient.GetStringAsync(apiUrl);
            var characters = JsonConvert.DeserializeObject<PeopleList>(response);
            return characters?.Results;
        }
            
        public async Task<People> GetPeople(string url)
        {
            using var httpClient = new HttpClient();            
            var response = await httpClient.GetStringAsync(url);
            var characters = JsonConvert.DeserializeObject<People>(response);
            return characters;
        }
    }
}

