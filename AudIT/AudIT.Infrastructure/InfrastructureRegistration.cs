﻿using System.Reflection;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.DocumentServices;
using AudIT.Applicationa.Contracts.Identity;
using AudIT.Applicationa.Services.AuthorizationServices;
using AudIT.Applicationa.Services.AuthServices;
using AudIT.Applicationa.Services.DocumentServices;
using AudIT.Applicationa.Services.EmailServices;
using AudIT.Applicationa.Services.UtilsServices;
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
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IStandaloneDocRepository, StandaloneDocRepository>();
        services.AddScoped<ITemplateDocRepository, TemplateDocRepository>();
        services.AddScoped<IAuditMissionRepository, AuditMissionRepository>();

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AudITContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthorization, AuthorizationService>();
        services.AddScoped<EmailService, EmailService>();
        services.AddScoped<UtilsService, UtilsService>();
        services.AddScoped<IDocumentManager, DocumentService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}