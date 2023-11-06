global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using FamChron.Web;
using FamChron.Web.Authentication;
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
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<AuthenticationStateProvider, UserAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
// 7047