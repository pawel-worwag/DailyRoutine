using System.Text.Json.Serialization;

namespace Identity.Application.Auth.Clients.GetAllRegisteredClients.Dto;

public record Client
{
    [JsonPropertyName("guid")]
    public required Guid Guid { get; init; }
    [JsonPropertyName("name")]
    public required string Name { get; init; } = string.Empty;
    [JsonPropertyName("redirection-endpoints")]
    public ICollection<string> RedirectionEndpoints { get; init; } = new List<string>(); 
}