global using ControWell.Shared;
global using System.Net.Http.Json;
global using ControWell.Client.Services.PozoService;
global using ControWell.Client.Services.UsuarioService;
global using ControWell.Client.Services.SuperHeroService;
using ControWell.Client;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ControWell.Client.Services.SuperHeroService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPozoService, PozoService>();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

await builder.Build().RunAsync();
