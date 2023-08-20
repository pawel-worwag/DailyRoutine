using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Attachments.UpdateAttachmentFile;

public record UpdateAttachmentFileRequest : IRequest
{
    public required Guid Guid { get; init; }
    public required string FileTempPath { get; init; }
};

internal class UpdateAttachmentFileHandler : IRequestHandler<UpdateAttachmentFileRequest>
{
    private readonly IAttachmentsStore _store;
    private readonly IMailerDbContext _dbc;

    public UpdateAttachmentFileHandler(IMailerDbContext dbc, IAttachmentsStore store)
    {
        _dbc = dbc;
        _store = store;
    }

    public async Task Handle(UpdateAttachmentFileRequest request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.AsNoTracking().FirstOrDefaultAsync(p=>p.Guid == request.Guid,cancellationToken);
        if (attachment is null)
        {
            throw new NotFoundException($"Attachment {request.Guid} not found.");
        }

        await _store.WriteFileAsync(request.Guid.ToString(),
            await File.ReadAllBytesAsync(request.FileTempPath, cancellationToken), cancellationToken);
    }
}