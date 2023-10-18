namespace Identity.Application.Auth.GetAuthorization;

public record AuthorizationResult
{
    public required bool IsValid { get; init; }
    public ICollection<string> Errors { get; init; } = new List<string>();
    public string RedirectUri { get; set; } = string.Empty;
}