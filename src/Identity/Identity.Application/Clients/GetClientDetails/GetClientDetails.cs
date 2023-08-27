using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Clients.GetClientDetails;

public record GetClientDetailsRequest : IRequest<Response>
{
    public required Guid Guid { get; init; }
}

internal class GetClientDetailsHandler : IRequestHandler<GetClientDetailsRequest, Response>
{
    private readonly IIdentityDbContext _dbc;

    public GetClientDetailsHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetClientDetailsRequest request, CancellationToken cancellationToken)
    {
        var client = await _dbc.Clients.Where(p => p.Guid == request.Guid).Include(p => p.RedirectionEndpoints)
            .FirstOrDefaultAsync(cancellationToken);
        if (client is null)
        {
            throw new NotFoundException($"Client {request.Guid} not found.");
        }

        return new Response
        {
            Guid = client.Guid,
            Name = client.Name,
            Endpoints = client.RedirectionEndpoints.Select(p => new Endpoint
            {
                Guid = p.Guid,
                Uri = p.Uri
            }).ToList()
        };
    }
}