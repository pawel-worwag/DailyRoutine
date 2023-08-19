namespace Mailer.Infrastructure.Common.Exceptions;

public class NotFoundException : InfrastructureException
{
    public NotFoundException(string? message) : base(message)
    {
    }
}