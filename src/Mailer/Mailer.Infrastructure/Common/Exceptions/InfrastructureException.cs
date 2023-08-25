using System.Net;
using Mailer.Shared.Abstractions.Exceptions;

namespace Mailer.Infrastructure.Common.Exceptions;

public abstract class InfrastructureException : CustomException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.InternalServerError;
    public override string Error { get; protected set; } = "unknown_error";
    public override string? ErrorUri { get; protected set; } = null;
    protected InfrastructureException(string? message) : base(message)
    {
    }

    protected InfrastructureException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}