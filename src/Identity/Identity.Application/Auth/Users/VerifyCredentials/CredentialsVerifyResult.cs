namespace Identity.Application.Auth.Users.VerifyCredentials;

public class CredentialsVerifyResult
{
    public bool IsValid { get; set; } = true;
    public string Error { get; set; } = string.Empty;
}