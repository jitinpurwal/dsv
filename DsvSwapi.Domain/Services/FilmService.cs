using DsvSwapi.Domain.Helper;
using DsvSwapi.Domain.Interfaces;
using DsvSwapi.Domain.Models;
using DsvSwapi.Domain.Response;
using Newtonsoft.Json;

namespace DsvSwapi.Domain.Services
{
    public class FilmService : IFilm
    {
        public async Task<IEnumerable<Film>> GetAllFilm() {

            using var httpClient = new HttpClient();
            var apiUrl = Constants.BaseURL + "films/";
            var response = await httpClient.GetStringAsync(apiUrl);
            var characters = JsonConvert.DeserializeObject<FilmList>(response);
            return characters?.Results;
        }
            
        public async Task<Film> GetFilm(string url)
        {
            using var httpClient = new HttpClient();            
            var response = await httpClient.GetStringAsync(url);
            var characters = JsonConvert.DeserializeObject<Film>(response);
            return characters;
        }
    }
}

