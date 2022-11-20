﻿namespace ControWell.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;

        public SuperHeroService(HttpClient http) {
            _http = http;
        }
        public List<SuperHero> Heroes { get; set;}=new List<SuperHero>();
        public List<Comic> Comics { get ;set; }=new List<Comic>();

        public async Task GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/SuperHero/comics");
            if (result != null)
                Comics = result;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/SuperHero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero no found");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
            if(result!=null)
                Heroes= result;
        }
    }
}
