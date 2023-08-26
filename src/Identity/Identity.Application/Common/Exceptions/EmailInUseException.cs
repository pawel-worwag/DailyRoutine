using System.Net;

namespace Identity.Application.Common.Exceptions;

public class EmailInUseException : ApplicationException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.BadRequest;
    public override string Error { get; protected set; } = "email_in_use";
    public EmailInUseException(string? message) : base(message)
    {
    }
}