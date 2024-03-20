using System.Reflection;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.DocumentServices;
using AudIT.Applicationa.Contracts.EmailServices;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Contracts.ObjectiveActionServices;
using AudIT.Applicationa.Services.AuthorizationServices;
using AudIT.Applicationa.Services.AuthServices;
using AudIT.Applicationa.Services.DocumentServices;
using AudIT.Applicationa.Services.EmailServices;
using AudIT.Applicationa.Services.ObjectiveActionServices;
using AudIT.Applicationa.Services.UtilsServices;
using AudiT.Domain.Entities;
using AudIT.Infrastructure.Repositories;
using AudIT.Infrastructure.Security.AuthorizationHandlers;
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
        services.AddDbContext<AudITContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("AudITContext")));
        services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
            });
        services.AddScoped
        (typeof(IRepository<>),
            typeof(BaseRepository<>));


        //register a policy for the EntityOwnerAuthorizationHandler
        services.AddAuthorization(options =>
        {
            options.AddPolicy("EntityOwnerPolicy", policy =>
            {
                policy.Requirements.Add(new EntityOwnerAuthorizationHandler());
            });
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

        services.AddScoped<IObjectiveActionService, ObjectiveActionService>();

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