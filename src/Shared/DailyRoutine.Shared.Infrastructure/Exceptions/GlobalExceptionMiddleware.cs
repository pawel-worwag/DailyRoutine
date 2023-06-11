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
            await context.Response.WriteAsJsonAsync(new Dto.ErrorResponse()
            {
                Errors = ex.Errors
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new Dto.ErrorResponse()
            {
                Errors = new List<string>(){ex.Message}
            });
        }
    }
}