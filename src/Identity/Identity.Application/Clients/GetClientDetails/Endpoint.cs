namespace Identity.Application.Clients.GetClientDetails;

public record Endpoint
{
    public required Guid Guid { get; init; }
    public required string Uri { get; init; }
}