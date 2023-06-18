using Identity.Application.Auth.Clients.GetAllRegisteredClients.Dto;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Client = Identity.Domain.Entities.Client;

namespace Identity.Application.Auth.Clients.GetAllRegisteredClients;

public class GetAllRegisteredClients : IRequest<Dto.Response>
{
    
}

internal class Handler : IRequestHandler<GetAllRegisteredClients, Dto.Response>
{
    private readonly IIdentityDbContext _dbc;

    public Handler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetAllRegisteredClients request, CancellationToken cancellationToken)
    {
        var clients = await _dbc.Clients.OrderBy(p => p.Name).Include(p => p.RedirectionEndpoints).ToListAsync(cancellationToken);
        var dto = new Dto.Response(){Clients = new List<Dto.Client>()};
        foreach (var client in clients)
        {
            var c = new Dto.Client()
            {
                Guid = client.Guid,
                Name = client.Name,
                RedirectionEndpoints = new List<string>()
            };
            foreach (var endpoint in client.RedirectionEndpoints)
            {
                c.RedirectionEndpoints.Add(endpoint.Uri);
            }
            dto.Clients.Add(c);
        }
        return dto;
    }
}