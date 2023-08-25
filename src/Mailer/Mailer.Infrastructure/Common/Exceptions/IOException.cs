namespace Mailer.Infrastructure.Common.Exceptions;

public class IOException : InfrastructureException
{
    public IOException(string? message) : base(message)
    {
    }

    public IOException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}