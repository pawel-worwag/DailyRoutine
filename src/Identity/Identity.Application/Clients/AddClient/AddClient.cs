using Identity.Application.Common.Interfaces;
using MediatR;

namespace Identity.Application.Clients.AddClient;

public record AddClientRequest : IRequest<Guid>
{
    public required string Name { get; init; }
    public required ICollection<string> Endpoints { get; init; }
}

internal class AddClientHandler : IRequestHandler<AddClientRequest, Guid>
{
    private readonly IIdentityDbContext _dbc;

    public AddClientHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Guid> Handle(AddClientRequest request, CancellationToken cancellationToken)
    {
        var client = new Domain.Client
        {
            Name = request.Name,
            RedirectionEndpoints = request.Endpoints.Select(p => new Domain.RedirectionEndpoint
            {
                Uri = p
            }).ToList()
        };
        _dbc.Clients.Add(client);
        await _dbc.SaveChangesAsync(cancellationToken);
        return client.Guid;
    }
}