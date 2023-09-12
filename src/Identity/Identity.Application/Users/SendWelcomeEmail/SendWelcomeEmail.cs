using Identity.Application.Common.Enums;
using Identity.Application.Common.Exceptions;
using Identity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Users.SendWelcomeEmail;

public record SendWelcomeEmailRequest : IRequest
{
    public required Guid Guid { get; init; }
};

internal class SendWelcomeEmailHandler : IRequestHandler<SendWelcomeEmailRequest>
{
    private readonly IIdentityDbContext _dbc;
    private readonly IMailBusProducer _mailBus;

    public SendWelcomeEmailHandler(IIdentityDbContext dbc, IMailBusProducer mailBus)
    {
        _dbc = dbc;
        _mailBus = mailBus;
    }

    public async Task Handle(SendWelcomeEmailRequest request, CancellationToken cancellationToken)
    {
        var user = await _dbc.Users
            .Include(p => p.Roles)
            .Include("UserClaims")
            .Include("EmailConfirmationToken")
            .Include("_passwordRecoveryTokens")
            .FirstOrDefaultAsync(p => p.Guid == request.Guid, cancellationToken);
        if (user is null)
        {
            throw new NotFoundException($"User {request.Guid} not found.");
        }

        var token = user.CreateEmailConfirmationToken(DateTime.UtcNow.AddDays(3));
        _dbc.Users.Update(user);
        await _dbc.SaveChangesAsync(cancellationToken);
        var dic = new Dictionary<string, string>
        {
            {"valid-before", TimeZoneInfo.ConvertTimeFromUtc(token.ValidBefore, user.TimeZone).ToString(user.Culture)},
            { "token", token.Token }
        };

        await _mailBus.SendMailAsync(EmailType.HELLO, "pl",
            new List<string>() { user.NormalizedEmail.Value },
            dic);
    }
}