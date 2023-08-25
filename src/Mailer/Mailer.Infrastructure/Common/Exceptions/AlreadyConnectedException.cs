namespace Mailer.Infrastructure.Common.Exceptions;

public class AlreadyConnectedException : InfrastructureException
{
    public AlreadyConnectedException(string? message) : base(message)
    {
    }
}