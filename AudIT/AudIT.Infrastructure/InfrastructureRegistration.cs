using System.Reflection;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.DocumentServices;
using AudIT.Applicationa.Contracts.EmailServices;
using AudIT.Applicationa.Contracts.ExportService;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Contracts.ObjectiveActionServices;
using AudIT.Applicationa.Models.Export.Activity;
using AudIT.Applicationa.Models.Export.Fiap;
using AudIT.Applicationa.Models.Export.ObjectiveAndActions;
using AudIT.Applicationa.Services.AuthorizationServices;
using AudIT.Applicationa.Services.AuthServices;
using AudIT.Applicationa.Services.DocumentServices;
using AudIT.Applicationa.Services.EmailServices;
using AudIT.Applicationa.Services.ExportServices.ExportAsCSVService;
using AudIT.Applicationa.Services.ExportServices.ExportFiapTemplateDoc;
using AudIT.Applicationa.Services.ExportServices.ExportTemplateObjAndActionXLS;
using AudIT.Applicationa.Services.ObjectiveActionServices;
using AudIT.Applicationa.Services.UtilsServices;
using AudiT.Domain.Entities;
using AudIT.Infrastructure.Repositories;
using AudIT.Infrastructure.Security.AuthorizationHandlers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AudIT.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.ConfigureExternalCookie(options =>
        {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.Name="MyCookie";
        });

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.None;
            options.CheckConsentNeeded = context => false;
            options.Secure = CookieSecurePolicy.Always;
        });

        services.AddDbContext<AudITContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("AudITContext")));
        // services.AddAuthentication(
        //     options =>
        //     {
        //         options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
        //         options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        //         options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
        //     });
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/api/v1/authentification/login";
                options.AccessDeniedPath = "/api/v1/authentification/accessdenied";
            });
        services.AddScoped
        (typeof(IRepository<>),
            typeof(BaseRepository<>));


        //register a policy for the EntityWriteOwnerAuthorizationHandler
        services.AddAuthorization(options =>
        {
            options.AddPolicy("EntityWritePolicy",
                policy => { policy.Requirements.Add(new EntityWriteOwnerAuthorizationHandler()); });
            options.AddPolicy("EntityReadPolicy",
                policy => { policy.Requirements.Add(new EntityReadOwnerAuthorizationHandler()); });
        });


        services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IStandaloneDocRepository, StandaloneDocRepository>();
        services.AddScoped<ITemplateDocRepository, TemplateDocRepository>();
        services.AddScoped<IAuditMissionRepository, AuditMissionRepository>();
        services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
        services.AddScoped<IObjectiveActionRepository, ObjectiveActionRepository>();
        services.AddScoped<IActionRiskRepository, ActionRiskRepository>();
        services.AddScoped<IRecommendationRepository, RecommendationRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IObjectiveActionService, ObjectiveActionService>();
        services.AddScoped<IBaseDocumentRepository, BaseDocumentRepository>();
        services.AddScoped<IObjectiveActionFiapRepository, ObjectiveActionFiapRepository>();

        services.AddScoped(typeof(IRepositoryAcces<>), typeof(BaseAccesRepository<>));
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        services.AddScoped(typeof(IRepositoryAcces<>), typeof(BaseAccesRepository<>));

        services.AddScoped(typeof(IExporterService<ObjectiveAndActionsExportModel>),
            provider => new ExportObjAndActionXLS());

        services.AddScoped(typeof(IExporterService<ActivityExportModel>),
            provider => new CSVExporterService<ActivityExportModel>());

        // services.AddScoped(typeof(IExporterService<FiapDocModel>),
        //     provider => new ExportFiapDoc<FiapDocModel>);

        services.AddScoped(typeof(IExporterService<FiapDocModel>),
            provider => new ExportFiapDoc());

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AudITContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthorization, AuthorizationService>();
        services.AddScoped<EmailService, EmailService>();
        services.AddScoped<UtilsService, UtilsService>();
        services.AddScoped<IDocumentManager, DocumentService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddHttpContextAccessor();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}