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
        services.AddDbContextPool<DailyRoutineDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DailyRutineDatabase")));
        services.AddScoped<IDailyRutineDbContext, DailyRoutineDbContext>();
        return services;
    }
}