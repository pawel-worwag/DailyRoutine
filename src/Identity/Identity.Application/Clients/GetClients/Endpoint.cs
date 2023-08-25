namespace Identity.Application.Clients.GetClients;

public record Endpoint
{
    public required Guid Guid { get; init; }
    public required string Uri { get; init; }
};