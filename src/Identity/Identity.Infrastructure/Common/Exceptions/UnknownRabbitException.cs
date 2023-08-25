using System.Net;

namespace Identity.Infrastructure.Common.Exceptions;

public class UnknownRabbitException : InfrastructureException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.InternalServerError;
    public override string Error { get; protected set; } = "infrastructure_error";
    public override string? ErrorUri { get; protected set; } = null;
    
    public UnknownRabbitException(string? message) : base(message)
    {
    }

    public UnknownRabbitException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}