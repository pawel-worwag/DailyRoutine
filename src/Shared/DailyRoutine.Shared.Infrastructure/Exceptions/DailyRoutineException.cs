using System.Net;

namespace DailyRoutine.Shared.Infrastructure.Exceptions;

public class DailyRoutineException : Exception
{
    public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.InternalServerError;
    public ICollection<string> Errors { get; init; } = new List<string>();
    
    public DailyRoutineException(HttpStatusCode statusCode, string error, string? description = null) : base(description)
    {
        StatusCode = statusCode;
        Errors = new List<string>(){error};
    }
    
    public DailyRoutineException(HttpStatusCode statusCode, ICollection<string> errors, string? description = null) : base(description)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

}