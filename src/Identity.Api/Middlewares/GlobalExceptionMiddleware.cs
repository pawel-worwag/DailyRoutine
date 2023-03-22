using System.Net;
using Identity.Shared.Commands.Auth;
using Identity.Shared.Common;

namespace Identity.Api.Middlewares;

/// <summary>
/// 
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (AuthException ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new AuthErrorResponse(ex.Error,ex.Message));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(ex.Message);
        }
    }
}

/// <summary>
/// 
/// </summary>
public static class GlobalExceptionmiddlewareExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}