using System.Net;

namespace Mailer.Application.Common.Exceptions;

public class UnableToComplyException : ApplicationException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.BadRequest;
    public override string Error { get; protected set; } = "unable_to_comply";
    
    public UnableToComplyException(string? message) : base(message)
    {
    }

}