using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TimbraApp;
using TimbraApp.Service;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");



// Configurazione di HttpClient con ApiBaseUrl per Dieci3kRestService
builder.Services.AddScoped(sp =>
{
    // Leggi la BaseAddress da una configurazione, ad esempio appsettings.json
    var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");


    if (string.IsNullOrEmpty(apiBaseUrl))
    {
        // Se non è configurato, usa l'indirizzo di base predefinito
        apiBaseUrl = builder.HostEnvironment.BaseAddress;
    }

    return new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
});




builder.Services.AddScoped<Dieci3kRestService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
