using Mailer.Application.Common.Interfaces;
using Mailer.Application.CustomExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.GetTemplateAttachments;

public record GetTemplateAttachmentsRequest : IRequest<Response>
{
    public required Guid TemplateGuid { get; init; }
}

internal class GetTemplateAttachmentsHandler : IRequestHandler<GetTemplateAttachmentsRequest, Response>
{
    private readonly IMailerDbContext _dbc;

    public GetTemplateAttachmentsHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetTemplateAttachmentsRequest request, CancellationToken cancellationToken)
    {
        var template = await _dbc.Templates.WithAllIncludes().Where(p => p.Guid == request.TemplateGuid)
            .FirstOrDefaultAsync(cancellationToken);
        if (template is null)
        {
            throw new Exception("Template not found");
        }

        return new Response
        {
            Attachments = template.Attachments.Select(p => new Attachment
            {
                Guid = p.Guid,
                Name = p.Name,
                MediaType = p.MediaType,
                Description = p.Description,
                Inline = p.Inline
            }).ToList()
        };
    }
}