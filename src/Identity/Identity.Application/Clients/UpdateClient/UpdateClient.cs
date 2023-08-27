using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Clients.UpdateClient;

public record UpdateClientRequest : IRequest
{
    public required Guid Guid { get; init; }
    public required string Name { get; init; }
    public required ICollection<string> Endpoints { get; init; }
}

internal class UpdateClientHandler : IRequestHandler<UpdateClientRequest>
{
    private readonly IIdentityDbContext _dbc;

    public UpdateClientHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var client = await _dbc.Clients.Include(p => p.RedirectionEndpoints)
            .FirstOrDefaultAsync(p => p.Guid == request.Guid, cancellationToken);
        if (client is null)
        {
            throw new NotFoundException($"Client {request.Guid} not found.");
        }

        client.Name = request.Name;
        client.RedirectionEndpoints = request.Endpoints.Select(p => new Domain.RedirectionEndpoint
        {
            Uri = p
        }).ToList();
        _dbc.Clients.Update(client);
        await _dbc.SaveChangesAsync(cancellationToken);
    }
}