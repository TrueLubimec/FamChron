using FamChron.Web;
using FamChron.Web.Pages;
using FamChron.Web.Services;
using FamChron.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7047/") });

builder.Services.AddScoped<IEventService, EventService>();

await builder.Build().RunAsync();
// 7047