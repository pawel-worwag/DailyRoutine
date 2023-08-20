using System.Net;
using Mailer.Domain.Common.Exceptions;
using Mailer.Infrastructure.Common.Exceptions;
using Mailer.Shared.Abstractions.Exceptions;
using ApplicationException = Mailer.Application.Common.Exceptions.ApplicationException;

namespace Mailer.Api.Common.Exceptions;

/// <summary>
/// 
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            switch (ex)
            {
                case DomainException:
                case InfrastructureException:
                case ApplicationException:
                case ApiException:
                {
                    var exception = (CustomException)ex;
                    context.Response.StatusCode = (int)exception.HttpCode;
                    await context.Response.WriteAsJsonAsync(new ErrorResponse
                    {
                        Error = exception.Error,
                        Description = exception.Message,
                        ErrorUri = exception.ErrorUri
                    });
                    break;
                }
                default:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsJsonAsync(new ErrorResponse
                    {
                        Error = "unknown_error",
                        Description = ex.Message
                    });
                    break;
                }
            }
        }
    }
}