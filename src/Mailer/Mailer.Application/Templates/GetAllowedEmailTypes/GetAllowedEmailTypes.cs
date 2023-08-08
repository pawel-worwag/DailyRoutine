using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.GetAllowedEmailTypes;

public record GetAllowedEmailTypesRequest : IRequest<GetAllowedEmailTypesResponse>
{
}

internal class GetAllowedEmailTypesHandler : IRequestHandler<GetAllowedEmailTypesRequest, GetAllowedEmailTypesResponse>
{
    private readonly IMailerDbContext _dbc;

    public GetAllowedEmailTypesHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<GetAllowedEmailTypesResponse> Handle(GetAllowedEmailTypesRequest request,
        CancellationToken cancellationToken)
    {
        var types = await _dbc.EmailTypes.Select(p => p.Name).ToListAsync(cancellationToken);
        return new GetAllowedEmailTypesResponse()
        {
            EmailTypes = types,
            AllCount = types.Count
        };
    }
}