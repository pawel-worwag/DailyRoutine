namespace Identity.Domain;

public class RedirectionEndpoint
{
    public int Id { get; init; }
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string Uri { get; set; } = string.Empty;
    protected int ClientId { get; set; }
    public Client Client { get; set; } = default!;
}