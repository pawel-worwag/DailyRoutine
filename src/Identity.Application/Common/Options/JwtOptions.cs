namespace Identity.Application.Common.Options;

public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int Expires { get; set; } = 3600;
    public IEnumerable<JwkOptions> Keys { get; set; } = new List<JwkOptions>();
}