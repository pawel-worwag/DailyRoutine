namespace Mailer.Infrastructure.Common.Exceptions;

public class PathTraversalException : InfrastructureException
{
    public PathTraversalException(string? message) : base(message)
    {
    }
}