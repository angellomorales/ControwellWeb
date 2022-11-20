using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.PozoService
{
    public class PozoService : IPozoService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PozoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager= navigationManager;
        }
        public List<Pozo> Pozos { get; set; }=new List<Pozo>();

        public async Task CreatePozo(Pozo pozo)
        {
            var resultado = await _http.PostAsJsonAsync("api/Pozo", pozo);
            await SetPozo(resultado);
        }

        private async Task SetPozo(HttpResponseMessage resultado)
        {
            var respuesta = await resultado.Content.ReadFromJsonAsync<List<Pozo>>();
            Pozos=respuesta;
            _navigationManager.NavigateTo("pozolist");
        }

        public async Task DeletePozo(int id)
        {
            var resultado = await _http.DeleteAsync($"api/Pozo/{id}");
            var respuesta = await resultado.Content.ReadFromJsonAsync<List<Pozo>>();
            Pozos = respuesta;
        }

        public async Task GetPozo()
        {
            var resultado = await _http.GetFromJsonAsync<List<Pozo>>("api/Pozo");
            if (resultado != null)
                Pozos = resultado;
        }

        public async Task<Pozo> GetSinglePozo(int id)
        {
            var resultado = await _http.GetFromJsonAsync<Pozo>($"api/Pozo/{id}");
            if (resultado != null)
                return resultado;
            throw new Exception("No encontrado");
        }

        public async Task UpdatePozo(Pozo pozo)
        {
            var resultado = await _http.PutAsJsonAsync($"api/Pozo/{pozo.Id}", pozo);            
            await SetPozo(resultado);
        }

        public Task GetPozos()
        {
            throw new NotImplementedException();
        }

        Task<Pozo> IPozoService.GetPozo()
        {
            throw new NotImplementedException();
        }

        Task<Pozo> IPozoService.CreatePozo(Pozo pozo)
        {
            throw new NotImplementedException();
        }

        Task<Pozo> IPozoService.UpdatePozo(Pozo pozo)
        {
            throw new NotImplementedException();
        }

        Task<Pozo> IPozoService.DeletePozo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
