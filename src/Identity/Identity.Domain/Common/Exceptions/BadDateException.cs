using System.Net;

namespace Identity.Domain.Common.Exceptions;

public class BadDateException : DomainException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.InternalServerError;
    public override string Error { get; protected set; } = "bad_date";
    public override string? ErrorUri { get; protected set; } = null;
    
    public BadDateException(string? message) : base(message)
    {
    }

}