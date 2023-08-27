using System.Net;

namespace Identity.Infrastructure.Common.Exceptions;

public class MailBusException : InfrastructureException
{
    public MailBusException(string? message) : base(message)
    {
    }

    public MailBusException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.InternalServerError;
    public override string Error { get; protected set; } = "mail_bus_error";
    public override string? ErrorUri { get; protected set; } = null;
}