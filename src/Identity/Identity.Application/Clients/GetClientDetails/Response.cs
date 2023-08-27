namespace Identity.Application.Clients.GetClientDetails;

public record Response
{
    public required Guid Guid { get; init; }
    public required string Name { get; init; }
    public required ICollection<Endpoint> Endpoints { get; init; }
}