using System.Net;

namespace DailyRoutine.Shared.Infrastructure.Exceptions;

public class CustomException : Exception
{
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.InternalServerError;
    public string Error { get; init; } = string.Empty;
    public string Description { get;init; } = string.Empty;
    
    public CustomException(HttpStatusCode statusCode, string error, string? description = null) : base(description)
    {
        StatusCode = statusCode;
        Error = error;
    }
}