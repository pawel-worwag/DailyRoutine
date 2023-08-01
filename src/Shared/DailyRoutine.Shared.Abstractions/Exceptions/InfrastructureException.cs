using DailyRoutine.Shared.Abstractions.Exceptions;
using System.Net;

namespace DailyRoutine.Shared.Infrastructure.Exceptions
{
    public class InfrastructureException : CustomException
    {
        public InfrastructureException(HttpStatusCode statusCode, string error, string? description = null) : base(statusCode, error, description)
        {
        }
    }
}
