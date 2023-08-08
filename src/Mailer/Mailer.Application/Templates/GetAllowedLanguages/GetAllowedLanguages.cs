using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.GetAllowedLanguages;

public record GetAllowedLanguagesRequest : IRequest<GetAllowedLanguagesResponse>
{
};

internal class GetAllowedLanguagesHandler : IRequestHandler<GetAllowedLanguagesRequest, GetAllowedLanguagesResponse>
{
    private readonly IMailerDbContext _dbc;

    public GetAllowedLanguagesHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<GetAllowedLanguagesResponse> Handle(GetAllowedLanguagesRequest request,
        CancellationToken cancellationToken)
    {
        var languages = await _dbc.Languages.OrderBy(p => p.CultureName)
            .Select(p => p.CultureName)
            .ToListAsync(cancellationToken);
        return new GetAllowedLanguagesResponse()
        {
            Languages = languages,
            AllCount = languages.Count
        };
    }
}