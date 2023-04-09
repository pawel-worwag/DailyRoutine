using System.Net;
using Identity.Shared.Enums;

namespace Identity.Shared.Exceptions;

public class ProblemException : Exception
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    public string Error { get; set; } = AuthErrorResponseNames.InvalidRequest;

    public ProblemException()
    {
            
    }

    public ProblemException(HttpStatusCode statusCode, string error, string? description = null):base(description)
    {
        StatusCode = statusCode;
        Error = error;
    }
}