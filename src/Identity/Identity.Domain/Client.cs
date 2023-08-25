namespace Identity.Domain;

public class Client
{
    public int Id { get; init; }
    public Guid Guid { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ICollection<RedirectionEndpoint> RedirectionEndpoints { get; set; } = new List<RedirectionEndpoint>();
}