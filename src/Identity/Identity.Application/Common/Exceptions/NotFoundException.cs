using System.Net;

namespace Identity.Application.Common.Exceptions;

public class NotFoundException : ApplicationException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.NotFound;
    public override string Error { get; protected set; } = "not_found";
    public NotFoundException(string? message) : base(message)
    {
    }

}