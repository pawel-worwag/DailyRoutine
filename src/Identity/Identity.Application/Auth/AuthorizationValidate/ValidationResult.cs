namespace Identity.Application.Auth.AuthorizationValidate;

public record ValidationResult
{
    public required bool IsValid { get; init; }
    public ICollection<string> Errors { get; init; } = new List<string>();
}