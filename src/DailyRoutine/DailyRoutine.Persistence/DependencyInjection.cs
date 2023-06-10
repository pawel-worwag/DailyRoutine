using DailyRoutine.Application.Comon.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyRoutine.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContextPool<DailyRutineDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DailyRutineDatabase")));
        services.AddScoped<IDailyRutineDbContext, DailyRutineDbContext>();
        return services;
    }
}