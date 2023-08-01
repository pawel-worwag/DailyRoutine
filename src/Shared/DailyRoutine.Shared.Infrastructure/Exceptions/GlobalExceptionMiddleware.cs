using System.Net;
using System.Text.Json;
using DailyRoutine.Shared.Abstractions.Exceptions;
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
        catch (Abstractions.Exceptions.CustomException ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Dto.ErrorResponse()
            {
                Error = ex.Error,
                Description = ex.Description,
                Details = new Dictionary<string, string> { {"exception_type", ex.GetType().FullName } }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new Dto.ErrorResponse()
            {
                Error = "unknown_error",
                Description =  ex.Message ,
                Details = new Dictionary<string, string> { { "exception_type", ex.GetType().FullName } }
            }) ;
        }
    }
}