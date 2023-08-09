using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.GetTemplates;

public record GetTemplatesRequest : IRequest<Response>
{
};

internal class GetTemplatesHandler : IRequestHandler<GetTemplatesRequest, Response>
{
    private readonly IMailerDbContext _dbc;

    public GetTemplatesHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetTemplatesRequest request, CancellationToken cancellationToken)
    {
        var types = await _dbc.EmailTypes
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Select(p => p.Name)
            .ToListAsync(cancellationToken);

        var languages = await _dbc.Languages
            .AsNoTracking()
            .OrderBy(p => p.CultureName)
            .Select(p => p.CultureName)
            .ToListAsync(cancellationToken);

        var list = types.SelectMany(x => languages, (x, y) => new TemplateListItem{ Type = x, Language = y, Template = null}).ToList();

        
        var templates = await _dbc.Templates
            .Include("_attachments")
            .Include(p=>p.Language)
            .Include(p=>p.Type)
            .AsNoTracking().ToListAsync(cancellationToken);

        foreach (var template in templates)
        {
            var dto = new Template
            {
                Guid = template.Guid,
                Subject = template.Subject,
                ReferencesCount = template.Attachments.Count
            };
            var item = list
                .FirstOrDefault(p => p.Type == template.Type.Name && p.Language == template.Language.CultureName);
            if (item != null) list.Remove(item);
            list.Add(new TemplateListItem
            {
                Type = template.Type.Name,
                Language = template.Language.CultureName,
                Template = dto
            });
        }

        return new Response
        {
            Templates = list.OrderBy(p => p.Type).ThenBy(p => p.Language).ToList()
        };
    }
}