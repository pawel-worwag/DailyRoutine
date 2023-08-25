using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Attachments.DeleteAttachment;

public record DeleteAttachmentRequest : IRequest
{
    public Guid Guid { get; init; }
};

internal class DeleteAttachmentHandler : IRequestHandler<DeleteAttachmentRequest>
{
    private readonly IAttachmentsStore _store;
    private readonly IMailerDbContext _dbc;


    public DeleteAttachmentHandler(IAttachmentsStore store, IMailerDbContext dbc)
    {
        _store = store;
        _dbc = dbc;
    }

    public async Task Handle(DeleteAttachmentRequest request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.Include(p => p.Templates)
            .FirstOrDefaultAsync(p => p.Guid == request.Guid,cancellationToken);
        if (attachment is null)
        {
            throw new NotFoundException($"Attachment {request.Guid} not found.");
        }

        if (attachment.Templates.Count != 0)
        {
            throw new UnableToComplyException("The attachment has references.");
        }

        _dbc.Attachments.Remove(attachment);
        await _dbc.SaveChangesAsync(cancellationToken);

        await _store.DeleteFileAsync(request.Guid.ToString(), cancellationToken);
    }
}