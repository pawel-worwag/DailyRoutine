using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Clients.DeleteClient;

public record DeleteClientRequest : IRequest
{
    public required Guid Guid { get; init; }
}

internal class DeleteClientHandler : IRequestHandler<DeleteClientRequest>
{
    private readonly IIdentityDbContext _dbc;

    public DeleteClientHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(DeleteClientRequest request, CancellationToken cancellationToken)
    {
        var client = await _dbc.Clients.Where(p => p.Guid == request.Guid).Include(p => p.RedirectionEndpoints)
            .FirstOrDefaultAsync(cancellationToken);
        if (client is null)
        {
            throw new NotFoundException($"Client {request.Guid} not found.");
        }

        _dbc.Clients.Remove(client);
        await _dbc.SaveChangesAsync(cancellationToken);
    }
}