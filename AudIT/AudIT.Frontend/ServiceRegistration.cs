using System.Net.Http.Headers;
using System.Security.Claims;
using Blazored.LocalStorage;
using Frontend.Contracts.Abstract_Services.ActionRiskService;
using Frontend.Contracts.Abstract_Services.ActivityService;
using Frontend.Contracts.Abstract_Services.AuditMissionService;
using Frontend.Contracts.Abstract_Services.CurrentUserAuditMissionService;
using Frontend.Contracts.Abstract_Services.DepartmentService;
using Frontend.Contracts.Abstract_Services.DocumentService;
using Frontend.Contracts.Abstract_Services.FiapService;
using Frontend.Contracts.Abstract_Services.InstitutionsService;
using Frontend.Contracts.Abstract_Services.ObjectiveActionService;
using Frontend.Contracts.Abstract_Services.ObjectiveService;
using Frontend.EntityViewModels.CurrentUserAuditMissionViewModel;
using Frontend.Services.ActionRiskServices;
using Frontend.Services.Activity;
using Frontend.Services.AuditMission;
using Frontend.Services.AuthentificationServices;
using Frontend.Services.CurrentUserAuditMissionService;
using Frontend.Services.Department;
using Frontend.Services.Document;
using Frontend.Services.FiapService;
using Frontend.Services.InstitutionServices;
using Frontend.Services.Misc;
using Frontend.Services.ObjectiveActionServices;
using Frontend.Services.ObjectiveServices;
using Havit.Blazor.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Syncfusion;
using Syncfusion.Blazor;

namespace Frontend;

public static class ServiceRegistration
{
    public static void AddProjectServices(this IServiceCollection services, WebAssemblyHostBuilder builder)
    {
        services.AddTransient<CookieHandler>();
        services.AddHxServices();
        services.AddRadzenComponents();
        services.AddSyncfusionBlazor();
        //Register Syncfusion license
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXlfcnRcR2JcVUR1WUI=");

        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        services.AddScoped<IAuditMissionService, AuditMissionService>();
        services.AddScoped<CustomAuthStateProvider>();
        services.AddScoped<IInstitutionService, InstitutionService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IObjectiveService, ObjectiveService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IFiapService, FiapService>();
        services.AddScoped<IObjectiveActionService, ObjectiveActionService>();
        services.AddScoped<IActionRiskService, ActionRiskService>();
        services.AddScoped<ICurrentUserAuditMissionService, CurrentUserAuditMissionService>();
        services.AddBlazoredLocalStorage();

        // services.AddScoped<ClaimsPrincipal>();
        services.AddScoped<DialogService>();
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