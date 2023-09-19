using System.Reflection;
using Identity.Application.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration cfg)
    {
        services.Configure<JwksOptions>(cfg.GetSection("Auth:Jwks"));
        //services.AddOptions<JwksOptions>("Auth:Jwks");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}