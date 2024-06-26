using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddFluentUIComponents();

builder.Services.AddSingleton<HttpClient>(new HttpClient { BaseAddress = new Uri("https://localhost:7025") });

await builder.Build().RunAsync();
