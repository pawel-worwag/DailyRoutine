using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Attachments.GetAttachments;

public record GetAttachmentsRequest : IRequest<GetAttachmentsResponse>
{
    public int Take { get; init; } = 50;
    public int Skip { get; init; } = 0;
};

internal class GetAttachmentsHandler : IRequestHandler<GetAttachmentsRequest, GetAttachmentsResponse>
{
    private readonly IMailerDbContext _dbc;

    public GetAttachmentsHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<GetAttachmentsResponse> Handle(GetAttachmentsRequest request, CancellationToken cancellationToken)
    {
        var records = await _dbc.Attachments.Include(p=>p.Templates).OrderBy(p => p.Name).Take(request.Take).Skip(request.Skip).AsNoTracking().ToListAsync(cancellationToken);
        var attachments = new List<Attachment>();

        foreach (var att in records)
        {
            attachments.Add(new Attachment()
            {
                Guid = att.Guid,
                Name = att.Name,
                MediaType = att.MediaType,
                Inline = att.Inline,
                Description = att.Description,
                ReferencesCount = att.Templates.Count
            });
        }
        
        var response = new GetAttachmentsResponse()
        {
            Attachments = attachments,
            AllCount = records.Count
        };
        return response;
    }
}