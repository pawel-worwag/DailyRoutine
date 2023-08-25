using System.Net;

namespace Identity.Shared.Abstractions.Exceptions;

public abstract class CustomException : Exception
{
    protected CustomException(string? message) : base(message)
    {
    }

    protected CustomException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public abstract HttpStatusCode HttpCode { get; protected set; }
    public abstract string Error { get; protected set; }
    public abstract string? ErrorUri { get; protected set; }
}