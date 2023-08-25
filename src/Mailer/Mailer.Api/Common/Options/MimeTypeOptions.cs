namespace Mailer.Api.Common.Options;

/// <summary>
/// 
/// </summary>
public record MimeTypeOptions
{
    /// <summary>
    /// 
    /// </summary>
    public ICollection<string> AllowedMimeTypes { get; init; } = new List<string>() { "image/png" };
}