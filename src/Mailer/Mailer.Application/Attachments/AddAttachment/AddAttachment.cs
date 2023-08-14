using System.Text.Json.Serialization;
using Mailer.Application.Common.Interfaces;
using Mailer.Domain;
using MediatR;

namespace Mailer.Application.Attachments.AddAttachment;

public record AddAttachmentRequest : IRequest<Guid>
{
    [JsonPropertyName("name")] public required string Name { get; init; }
    [JsonPropertyName("media-type")] public required string MediaType { get; init; }
    [JsonPropertyName("description")] public required string Description { get; init; }
    [JsonPropertyName("inline")] public required bool Inline { get; init; }
    [JsonPropertyName("file")] public required string FileTempPath { get; init; }
};

internal class AddAttachmentHandler : IRequestHandler<AddAttachmentRequest, Guid>
{
    private readonly IAttachmentsStore _store;
    private readonly IMailerDbContext _dbc;

    public AddAttachmentHandler(IAttachmentsStore store, IMailerDbContext dbc)
    {
        _store = store;
        _dbc = dbc;
    }

    public async Task<Guid> Handle(AddAttachmentRequest request, CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid();
        var file = File.ReadAllBytes(request.FileTempPath);
        await _store.WriteFileAsync(guid.ToString(), file, cancellationToken);
        _dbc.Attachments.Add(new Attachment()
        {
            Guid = guid,
            Name = request.Name,
            MediaType = request.MediaType,
            Inline = request.Inline,
            Description = request.Description
        });
        await _dbc.SaveChangesAsync(cancellationToken);
        return guid;
    }
};