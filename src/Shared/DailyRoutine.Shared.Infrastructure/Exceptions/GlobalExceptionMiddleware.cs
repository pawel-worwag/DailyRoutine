using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace DailyRoutine.Shared.Infrastructure.Exceptions;

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
        catch (DailyRoutineException ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)ex.StatusCode;
            var json = JsonSerializer.Serialize(new Dto.ErrorResponse()
            {
                Errors = ex.Errors
            });
            _logger.LogInformation(json);
            await context.Response.WriteAsync(json);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var json = JsonSerializer.Serialize(new Dto.ErrorResponse()
            {
                Errors = new List<string>(){ex.Message}
            });
            _logger.LogInformation(json);
            await context.Response.WriteAsync(json);
        }
    }
}