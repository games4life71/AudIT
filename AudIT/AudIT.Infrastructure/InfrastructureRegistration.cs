using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Services.AuthorizationServices;
using AudIT.Applicationa.Services.AuthServices;
using AudIT.Applicationa.Services.EmailServices;
using AudiT.Domain.Entities;
using AudIT.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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

        services.AddScoped
        (typeof(IRepository<>),
            typeof(BaseRepository<>));
        services.AddScoped<IInstitutionRepository, InstitutionRepository>();
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AudITContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthorization, AuthorizationService>();
        services.AddScoped<EmailService, EmailService>();
        return services;
    }
}