using System.Net;
using Mailer.Shared.Abstractions.Exceptions;

namespace Mailer.Application.Common.Exceptions;

public abstract class ApplicationException : CustomException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.InternalServerError;
    public override string Error { get; protected set; } = "unknown_error";
    public override string? ErrorUri { get; protected set; } = null;
    protected ApplicationException(string? message) : base(message)
    {
    }
}