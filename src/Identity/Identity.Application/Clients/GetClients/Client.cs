namespace Identity.Application.Clients.GetClients;

public record Client
{
    public required Guid Guid { get; init; }
    public required string Name { get; init; }
    public required ICollection<Endpoint> Endpoints { get; init; }
};