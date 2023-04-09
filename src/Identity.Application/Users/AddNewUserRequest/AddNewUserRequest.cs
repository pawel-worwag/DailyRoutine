using FluentValidation;
using Identity.Domain.Entities;
using Identity.Shared.Commands.Users.AddNewUser;
using Identity.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Users.AddNewUserRequest;

public class AddNewUserRequest : IRequest<Guid>
{
    public AddNewUserQuery Dto { get; set; } = new AddNewUserQuery();
}

public sealed class AddNewUserRequestValidator : AbstractValidator<AddNewUserRequest>, IAuthValidator
{
    public AddNewUserRequestValidator()
    {
        RuleFor(e => e.Dto).NotNull().WithMessage("Dto is null");
        RuleFor(e => e.Dto.DisplayName).NotEmpty().WithMessage("Field 'DisplayName' cannot be empty.");
        RuleFor(e => e.Dto.Email).NotEmpty().WithMessage("Field 'Email' cannot be empty.");
    }
}

public class AddNewUserRequestHandler : IRequestHandler<AddNewUserRequest, Guid>
{
    private readonly UserManager<User> _usersManager;

    public AddNewUserRequestHandler(UserManager<User> usersManager)
    {
        _usersManager = usersManager;
    }
    // TODO modify error handling 
    public async Task<Guid> Handle(AddNewUserRequest request, CancellationToken cancellationToken)
    {
        var user = MapDtoToDomainUser(request.Dto);
        IdentityResult result;
        if (request.Dto.Password is null)
        {
            result = await _usersManager.CreateAsync(user);
        }
        else
        {
            result = await _usersManager.CreateAsync(user, request.Dto.Password);
        }

        if (!result.Succeeded)
        {
            throw new Exception($"Adding user goes wrong. {result}");
        }

        foreach (var role in request.Dto.Roles)
        {
            await _usersManager.AddToRoleAsync(user, role);
        }
        
        return user.Guid;
    }

    private User MapDtoToDomainUser(AddNewUserQuery dto)
    {
        return new User()
        {
            Email = dto.Email,
            EmailConfirmed = dto.EmailConfirmed,
            UserName = dto.Email,
            DisplayName = dto.DisplayName
        };
    }
}
