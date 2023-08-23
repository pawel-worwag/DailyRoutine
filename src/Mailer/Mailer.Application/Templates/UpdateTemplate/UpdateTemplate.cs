using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using Mailer.Application.CustomExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.UpdateTemplate;

public record UpdateTemplateRequest : IRequest
{
    public required Guid Guid { get; init; }
    public required string Subject { get; init; }
    public required string BodyEncoded { get; init; }
    public required ICollection<Guid> Attachments { get; init; }
}

internal class UpdateTemplateHandler : IRequestHandler<UpdateTemplateRequest>
{
    private readonly IMailerDbContext _dbc;

    public UpdateTemplateHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(UpdateTemplateRequest request, CancellationToken cancellationToken)
    {
        var template = await _dbc.Templates.WithAllIncludes()
            .FirstOrDefaultAsync(p => p.Guid == request.Guid, cancellationToken);

        if (template is null)
        {
            throw new NotFoundException($"Template {request.Guid} not found.");
        }

        template.Subject = request.Subject;
        template.BodyEncoded = request.BodyEncoded;
        var attachments = await _dbc.Attachments.Where(p => request.Attachments.Contains(p.Guid)).ToListAsync(cancellationToken);
        template.ClearAttachments();
        template.AddAttachments(attachments);

        _dbc.Templates.Update(template);
        await _dbc.SaveChangesAsync(cancellationToken);
    }
}