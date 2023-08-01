using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DailyRoutine.Shared.Abstractions.Exceptions
{
    public class DomainException : CustomException
    {
        public DomainException(HttpStatusCode statusCode, string error, string? description = null) : base(statusCode, error, description)
        {
        }
    }
}
