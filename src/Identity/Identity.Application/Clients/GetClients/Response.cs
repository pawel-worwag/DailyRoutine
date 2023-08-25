namespace Identity.Application.Clients.GetClients;

public record Response
{
    public required ICollection<Client> Clients { get; init; }
};