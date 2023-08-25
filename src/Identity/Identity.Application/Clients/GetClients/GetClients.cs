using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Clients.GetClients;

public record GetClientsRequest : IRequest<Response>
{
    
};

internal class GetClientsHandler : IRequestHandler<GetClientsRequest,Response>
{
    private readonly IIdentityDbContext _dbc;

    public GetClientsHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetClientsRequest request, CancellationToken cancellationToken)
    {
        var clients = await _dbc.Clients.AsNoTracking().Include(p => p.RedirectionEndpoints).OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
        return new Response
        {
            Clients = clients.Select(p => new Client
            {
                Guid = p.Guid,
                Name = p.Name,
                Endpoints = p.RedirectionEndpoints.Select(q=>new Endpoint
                {
                    Guid = q.Guid,
                    Uri = q.Uri
                }).ToList()
            }).ToList()
        };
    }
}