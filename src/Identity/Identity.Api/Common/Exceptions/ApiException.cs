using System.Net;
using Identity.Shared.Abstractions.Exceptions;

namespace Identity.Api.Common.Exceptions;

/// <summary>
/// 
/// </summary>
public abstract class ApiException : CustomException
{
    /// <summary>
    /// 
    /// </summary>
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.InternalServerError;
    /// <summary>
    /// 
    /// </summary>
    public override string Error { get; protected set; } = "unknown_error";
    /// <summary>
    /// 
    /// </summary>
    public override string? ErrorUri { get; protected set; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    protected ApiException(string? message) : base(message)
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    protected ApiException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}