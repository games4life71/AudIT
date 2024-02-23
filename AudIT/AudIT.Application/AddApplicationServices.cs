using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AudIT.Applicationa;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies
            (
                Assembly.GetExecutingAssembly()));
    }
}