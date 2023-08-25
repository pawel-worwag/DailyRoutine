using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Attachments.DownloadAttachment;

public record DownloadAttachment : IRequest<Response>
{
    public required Guid Guid { get; init; }
};

internal class Handler : IRequestHandler<DownloadAttachment, Response>
{
    private readonly IAttachmentsStore _store;
    private readonly IMailerDbContext _dbc;

    public Handler(IAttachmentsStore store, IMailerDbContext dbc)
    {
        _store = store;
        _dbc = dbc;
    }

    public async Task<Response> Handle(DownloadAttachment request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.AsNoTracking().Where(p => p.Guid == request.Guid)
            .FirstOrDefaultAsync(cancellationToken);
        if (attachment is null)
        {
            throw new NotFoundException($"Attachment {request.Guid} not found.");
        }

        var filePath = Path.GetTempFileName();
        await System.IO.File.WriteAllBytesAsync(filePath,
            await _store.ReadFileAsync(attachment.Guid.ToString(), cancellationToken),cancellationToken);
        return new Response
        {
            FileTempPath = filePath,
            Name = attachment.Name,
            MimeType = attachment.MediaType
        };
    }
}