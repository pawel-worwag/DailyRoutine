using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Roles.GetRoles;

public record GetRolesRequest : IRequest<Response>
{
    
}

internal class GetRolesHandler : IRequestHandler<GetRolesRequest,Response>
{
    private readonly IIdentityDbContext _dbc;

    public GetRolesHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var roles = await _dbc.Roles.AsNoTracking().OrderBy(p => p.NormalizedName)
            .ToListAsync(cancellationToken);
        return new Response
        {
            Roles = roles.Select(p => new Role { NormalizedName = p.NormalizedName.Value }).ToList()
        };
    }
}