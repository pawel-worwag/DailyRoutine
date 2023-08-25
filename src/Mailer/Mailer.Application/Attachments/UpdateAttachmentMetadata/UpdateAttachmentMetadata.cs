using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Attachments.UpdateAttachmentMetadata;

public record UpdateAttachmentMetadataRequest : IRequest
{
    public required Guid Guid { get; init; }
    public required string Name { get; init; }
    public required string MediaType { get; init; }
    public required string Description { get; init; }
    public required bool Inline { get; init; }
};

internal class UpdateAttachmentMetadataHandler : IRequestHandler<UpdateAttachmentMetadataRequest>
{
    private readonly IMailerDbContext _dbc;

    public UpdateAttachmentMetadataHandler(IMailerDbContext dbc)
    {
        _dbc = dbc;
    }

    public async Task Handle(UpdateAttachmentMetadataRequest request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.FirstOrDefaultAsync(p => p.Guid == request.Guid, cancellationToken);
        if (attachment is null)
        {
            throw new NotFoundException($"Attachment {request.Guid} not found");
        }

        attachment.Name = request.Name;
        attachment.MediaType = request.MediaType;
        attachment.Inline = request.Inline;
        attachment.Description = request.Description;

        _dbc.Attachments.Update(attachment);
        await _dbc.SaveChangesAsync(cancellationToken);
    }
}