using System.Net;
using Identity.Shared.Enums;

namespace Identity.Shared.Commands.Auth;

public class AuthException : Exception
{
    public HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
    public string Error { get; set; } = AuthErrorResponseNames.InvalidRequest;
    public string? Description { get; set; } = null;
    
    public AuthException()
    {
            
    }

    public AuthException(HttpStatusCode statusCode, string error, string? description = null)
    {
        StatusCode = statusCode;
        Error = error;
        Description = description;
    }
}