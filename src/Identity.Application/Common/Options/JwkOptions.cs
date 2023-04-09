namespace Identity.Application.Common.Options;

public class JwkOptions
{
    public string KeyFile { get; set; } = string.Empty;
    public string? KeyPassword { get; set; } = null;
}