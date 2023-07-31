using Identity.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContextPool<IdentityDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("IdentityDatabase")));
        services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        return services;
    }
}