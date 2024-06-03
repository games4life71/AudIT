using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend;
using Frontend.Contracts.Abstract_Services.AuditMissionService;
using Frontend.Services;
using Frontend.Services.AuditMission;
using Frontend.Services.AuthentificationServices;
using Frontend.Services.Misc;
using Havit.Blazor.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
//
// var builder = WebAssemblyHostBuilder.CreateDefault(args);
// builder.RootComponents.Add<App>("#app");
// builder.RootComponents.Add<HeadOutlet>("head::after");
//
// // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
// builder.Services.AddTransient<CookieHandler>();
//
// builder.Services.AddHxServices();
// builder.Services.AddRadzenComponents();
// builder.Services.AddScoped<IAuditMissionService, AuditMissionService>();
// //register the CustomAuthStateProvider
// builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
// builder.Services.AddScoped<CustomAuthStateProvider>();
// builder.Services.AddScoped(sp =>
// {
//     var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
//     httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//     var cookieHandler = sp.GetRequiredService<CookieHandler>();
//     cookieHandler.InnerHandler = new HttpClientHandler();
//     httpClient = new HttpClient(cookieHandler) { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
//     return httpClient;
// });
// // builder.Configuration.Bind("DetailedErrors", true);
// await builder.Build().RunAsync();

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddProjectServices(builder);

await builder.Build().RunAsync();