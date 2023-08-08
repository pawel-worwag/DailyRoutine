using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.GetAllowedLanguages;

public record GetAllowedLanguagesRequest : IRequest<Response>
{
};

internal class GetAllowedLanguagesHandler : IRequestHandler<GetAllowedLanguagesRequest, Response>
{
    private readonly IMailerDbContext _dbc;

    public GetAllowedLanguagesHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetAllowedLanguagesRequest request,
        CancellationToken cancellationToken)
    {
        var languages = await _dbc.Languages.OrderBy(p => p.CultureName)
            .Select(p => p.CultureName)
            .ToListAsync(cancellationToken);
        return new Response()
        {
            Languages = languages,
            AllCount = languages.Count
        };
    }
}