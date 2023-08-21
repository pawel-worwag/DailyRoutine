using System.Text.Json.Serialization;
using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using Mailer.Application.CustomExtensions;
using Mailer.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.AddTemplate;

public record AddTemplateRequest : IRequest<Guid>
{
    public required string Type { get; init; }
    public required string Language { get; init; }
    public required string Subject { get; init; }
    public required string BodyEncoded { get; init; }
    public required ICollection<Guid> Attachments { get; init; }
};

internal class AddTemplateHandler : IRequestHandler<AddTemplateRequest, Guid>
{
    private readonly IMailerDbContext _dbc;

    public AddTemplateHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Guid> Handle(AddTemplateRequest request, CancellationToken cancellationToken)
    {
        var type = await _dbc.EmailTypes.FirstOrDefaultAsync(p => p.Name == request.Type, cancellationToken);
        
        var language = await _dbc.Languages.FirstOrDefaultAsync(p => p.CultureName == request.Language, cancellationToken);

        if (type is null || language is null)
        {
            throw new NotFoundException($"Type or language not found.");
        }

        var count =await _dbc.Templates.WithAllIncludes().AsNoTracking()
            .Where(p => p.Language.CultureName == request.Language && p.Type.Name == request.Type)
            .CountAsync(cancellationToken);

        if (count > 0)
        {
            throw new AlreadyExistsException($"Template already exists.");
        }

        var attachments = await _dbc.Attachments.Where(p => request.Attachments.Contains(p.Guid)).ToListAsync(cancellationToken);
        
        var template = new Template(type, language,attachments)
        {
            Subject = request.Subject,
            BodyEncoded = request.BodyEncoded
        };

        await _dbc.Templates.AddAsync(template,cancellationToken);
        await _dbc.SaveChangesAsync(cancellationToken);
        return template.Guid;
    }
}