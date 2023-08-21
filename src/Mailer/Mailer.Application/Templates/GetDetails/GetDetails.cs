using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using Mailer.Application.CustomExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Templates.GetDetails;

public record GetDetailsRequest : IRequest<Response>
{
    public required Guid Guid { get; init; }
}

internal class GetDetailsHandler : IRequestHandler<GetDetailsRequest, Response>
{
    private readonly IMailerDbContext _dbc;

    public GetDetailsHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<Response> Handle(GetDetailsRequest request, CancellationToken cancellationToken)
    {
        var template = await _dbc.Templates.WithAllIncludes().AsNoTracking()
            .FirstOrDefaultAsync(p => p.Guid == request.Guid, cancellationToken);
        if (template is null)
        {
            throw new NotFoundException($"Template {request.Guid} not found.");
        }

        return new Response
        {
            Guid = template.Guid,
            Language = template.Language.CultureName,
            Type = template.Type.Name,
            Subject = template.Subject,
            BodyEncoded = template.BodyEncoded,
            Attachments = template.Attachments.Select(p=>new Attachment
            {
                Guid = p.Guid,
                Name = p.Name,
                MediaType = p.MediaType,
                InLine = p.Inline,
                Description = p.Description
            }).ToList()
        };
    }
}