using Identity.Domain.Entities;
using Identity.Shared.Commands.Users.GetUsersList;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.GetUsersListRequest;

public class GetUsersListRequest : IRequest<GetUsersListResponse>
{
    public int Take { get; set; } = 50;
    public int Skip { get; set; } = 0;
}

public class GetUsersListRequestHandler : IRequestHandler<GetUsersListRequest, GetUsersListResponse>
{
    private readonly UserManager<Domain.Entities.User> _usersManager;

    public GetUsersListRequestHandler(UserManager<User> usersManager)
    {
        _usersManager = usersManager;
    }

    public async Task<GetUsersListResponse> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
    {
        var users = await _usersManager.Users.OrderBy(p => p.NormalizedEmail).Take(request.Take).Skip(request.Skip).ToListAsync();
        GetUsersListResponse result = new();
        result.Count = await _usersManager.Users.CountAsync();
        foreach (var user in users)
        {
            var dto = MapDomainUserToDto(user);
            dto.Roles =  await _usersManager.GetRolesAsync(user);
            result.Users.Add(dto);
        }
        return result;
    }

    private UserDto MapDomainUserToDto(User user)
    {
        var dto = new UserDto()
        {
            Email = user.Email,
            DisplayName = user.DisplayName,
            EmailConfirmed = user.EmailConfirmed,
            LockoutEnd = user.LockoutEnd,
            AccessFailedCount = user.AccessFailedCount,
        };
        return dto;
    }
}