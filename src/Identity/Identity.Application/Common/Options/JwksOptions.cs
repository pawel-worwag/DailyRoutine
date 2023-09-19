namespace Identity.Application.Common.Options;

public class JwksOptions
{
    public ICollection<JwKey> Keys { get; set; } = new List<JwKey>();
};

public class JwKey
{
    public string Kid { get; set; } = string.Empty;
    public string KeyFile { get; set; } = string.Empty;
    public string? KeyPassword { get; set; } = null;
}