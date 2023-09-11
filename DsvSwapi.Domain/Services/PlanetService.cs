using DsvSwapi.Domain.Helper;
using DsvSwapi.Domain.Interfaces;
using DsvSwapi.Domain.Models;
using DsvSwapi.Domain.Response;
using Newtonsoft.Json;

namespace DsvSwapi.Domain.Services
{
    public class PlanetService : IPlanet
    {
        public async Task<IEnumerable<Planet>> GetAllPlanet() {

            using var httpClient = new HttpClient();
            var apiUrl = Constants.BaseURL + "planets/";
            var response = await httpClient.GetStringAsync(apiUrl);
            var characters = JsonConvert.DeserializeObject<PlanetList>(response);
            return characters?.Results;
        }
            
        public async Task<Planet> GetPlanet(string url)
        {
            using var httpClient = new HttpClient();            
            var response = await httpClient.GetStringAsync(url);
            var characters = JsonConvert.DeserializeObject<Planet>(response);
            return characters;
        }
    }
}

