namespace Identity.Application.Auth.Clients.VerifyClient;

public class ClientVerifyResult
{
    public bool IsValid { get; set; } = true;
    public string Error { get; set; } = string.Empty;
}