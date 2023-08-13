using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Attachments.GetDetails;

public record GetDetailsRequest : IRequest<Response>
{
    public required Guid Guid { get; init; }
};

internal class GetDetailsHandler:IRequestHandler<GetDetailsRequest,Response>
{
    private readonly IMailerDbContext _dbc;

    public GetDetailsHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetDetailsRequest request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.AsNoTracking()
            .Where(p => p.Guid == request.Guid)
            .Include(p => p.Templates).ThenInclude(p => p.Language)
            .Include(p => p.Templates).ThenInclude(p => p.Type)
            .FirstOrDefaultAsync(cancellationToken);

        if (attachment is null)
        {
            throw new Exception($"Attachment {request.Guid} not found.");
        }

        var templates = attachment.Templates.Select(p => new Template
        {
            Guid = p.Guid,
            Language = p.Language.CultureName,
            Type = p.Type.Name
        }).ToList();
        
        return new Response
        {
            Guid = attachment.Guid,
            Name = attachment.Name,
            MediaType = attachment.MediaType,
            Description = attachment.Description,
            Inline = attachment.Inline,
            Templates = templates
        };
    }
};