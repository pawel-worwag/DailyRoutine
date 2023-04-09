namespace Identity.Application.Common.Options;

public class JwksOptions
{
    public IEnumerable<JwkOptions> Keys { get; set; } = new List<JwkOptions>();
}