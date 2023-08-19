namespace Mailer.Infrastructure.Common.Exceptions;

public class SmtpException : InfrastructureException
{
    public SmtpException(string? message) : base(message)
    {
    }

    public SmtpException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}