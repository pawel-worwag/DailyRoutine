using System.Net;

namespace Mailer.Api.Common.Exceptions;

/// <summary>
/// 
/// </summary>
public class EmptyFileException : ApiException
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public EmptyFileException(string? message) : base(message)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public EmptyFileException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public override HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.BadRequest;
    
    /// <summary>
    /// 
    /// </summary>
    public override string Error { get; protected set; } = "empty_file";
}