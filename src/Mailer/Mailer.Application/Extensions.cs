using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}