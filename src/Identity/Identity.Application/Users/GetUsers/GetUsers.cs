using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.GetUsers;

public record GetUsersRequest : IRequest<Response>
{
    public required int Take { get; init; }
    public required int Skip { get; init; }
};

internal class GetUsersHandler : IRequestHandler<GetUsersRequest, Response>
{
    private readonly IIdentityDbContext _dbc;

    public GetUsersHandler(IIdentityDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var count = await _dbc.Users.CountAsync(cancellationToken);
        var users = await _dbc.Users.AsNoTracking()
            .Include(p => p.Roles)
            .Take(request.Take)
            .Skip(request.Skip).ToListAsync(cancellationToken);
        return new Response
        {
            AllCount = count,
            Users = users.Select(p=>new User
            {
                Guid = p.Guid,
                NormalizedEmailAddress = p.NormalizedEmail.Value,
                EmailConfirmed = p.EmailConfirmed
            }).ToList()
        };
    }
}