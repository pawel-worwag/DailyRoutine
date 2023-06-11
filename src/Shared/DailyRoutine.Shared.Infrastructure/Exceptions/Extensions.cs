using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DailyRoutine.Shared.Infrastructure.Exceptions;

public static class Extensions
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();
        return app;
    }
}