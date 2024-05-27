using System.Net.Http.Headers;
using Frontend.Contracts.Abstract_Services.AuditMissionService;
using Frontend.Services.AuditMission;
using Frontend.Services.AuthentificationServices;
using Frontend.Services.Misc;
using Havit.Blazor.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

namespace Frontend;

public static class ServiceRegistration
{
    public static void AddProjectServices(this IServiceCollection services, WebAssemblyHostBuilder builder)
    {
        services.AddTransient<CookieHandler>();
        services.AddHxServices();
        services.AddRadzenComponents();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        services.AddScoped<IAuditMissionService, AuditMissionService>();
        services.AddScoped<CustomAuthStateProvider>();
        services.AddScoped(sp =>
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var cookieHandler = sp.GetRequiredService<CookieHandler>() ??
                                throw new ArgumentNullException("sp.GetRequiredService<CookieHandler>()");
            cookieHandler.InnerHandler = new HttpClientHandler();
            httpClient = new HttpClient(cookieHandler) { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            return httpClient;
        });
    }
}

