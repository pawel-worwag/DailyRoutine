using System.Net;

namespace Mailer.Application.Common.Exceptions;

public class AlreadyExistsException : ApplicationException
{
    public AlreadyExistsException(string? message) : base(message)
    {
    }

    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.BadRequest;
    public override string Error { get; protected set; } = "already-exists";
}