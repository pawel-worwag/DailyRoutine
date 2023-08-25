using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Roles.GetRoles;

public record GetRolesRequest : IRequest<Response>
{
}

internal class GetRolesHandler : IRequestHandler<GetRolesRequest, Response>
{
    private readonly IIdentityDbContext _dbc;

    public GetRolesHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var roles = await _dbc.Roles.AsNoTracking()
            .Include(p => p.Claims)
            .OrderBy(p => p.NormalizedName)
            .ToListAsync(cancellationToken);

        return new Response
        {
            Roles = roles.Select(p => new Role
            {
                NormalizedName = p.NormalizedName.Value,
                Claims = p.Claims.Select(q => new Claim
                {
                    Type = q.ClaimType, 
                    Value = q.ClaimValue
                }).ToList()
            }).ToList()
        };
    }
}