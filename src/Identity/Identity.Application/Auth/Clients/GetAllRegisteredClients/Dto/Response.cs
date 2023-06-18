using System.Text.Json.Serialization;

namespace Identity.Application.Auth.Clients.GetAllRegisteredClients.Dto;

public record Response
{
    [JsonPropertyName("clients")]
    public required ICollection<Client> Clients { get; init; } = new List<Client>();
}