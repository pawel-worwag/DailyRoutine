using System.Net;

namespace Mailer.Infrastructure.Common.Exceptions;

public class NotFoundException : InfrastructureException
{
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.NotFound;
    public override string Error { get; protected set; } = "not_found";
    public NotFoundException(string? message) : base(message)
    {
    }
}