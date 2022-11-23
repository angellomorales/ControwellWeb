using ControWell.Shared;
using Microsoft.AspNetCore.Components;

namespace ControWell.Client.Services.AlarmaService
{
    public class AlarmaService : IAlarmaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public AlarmaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }



        public List<Alarma> Alarmas { get; set; } = new List<Alarma>();
        public List<VariableProceso> VariableProcesos { get ; set; }= new List<VariableProceso>();
        public List<Pozo> Pozos { get; set; }=new List<Pozo>();

      
    }
}
