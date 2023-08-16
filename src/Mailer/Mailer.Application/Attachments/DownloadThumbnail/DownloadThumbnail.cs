using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;

namespace Mailer.Application.Attachments.DownloadThumbnail;

public record DownloadThumbnailRequest : IRequest<Response>
{
    public required Guid Guid { get; init; }
};

internal class DownloadThumbnailHandler : IRequestHandler<DownloadThumbnailRequest, Response>
{
    private readonly IAttachmentsStore _store;
    private readonly IMailerDbContext _dbc;

    public DownloadThumbnailHandler(IAttachmentsStore store, IMailerDbContext dbc)
    {
        _store = store;
        _dbc = dbc;
    }

    public async Task<Response> Handle(DownloadThumbnailRequest request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.AsNoTracking().Where(p => p.Guid == request.Guid)
            .FirstOrDefaultAsync(cancellationToken);
        if (attachment is null)
        {
            throw new Exception($"Attachment {request.Guid} not found.");
        }

        if (attachment.MediaType != "image/png")
        {
            throw new Exception($"Type {attachment.MediaType} is not supported yet.");
        }
        
        var filePath = Path.GetTempFileName();
        await System.IO.File.WriteAllBytesAsync(filePath,
            await _store.ReadFileAsync(attachment.Guid.ToString(), cancellationToken),cancellationToken);
        
        var bitmap = SKBitmap.Decode(filePath);
        var info = bitmap.Info;

        var height = (info.Height * 150) / info.Width;
        var scaled = bitmap.Resize(new SKImageInfo(150, height),SKFilterQuality.Medium);

        var newFilePath = Path.GetTempFileName();

        using var data = scaled.Encode(SKEncodedImageFormat.Png, 100);
        await using var stream = File.OpenWrite(newFilePath);
        data.SaveTo(stream);
        
        File.Delete(filePath);

        return new Response
        {
        FileTempPath = newFilePath,
        Name = "thumb_"+attachment.Name
        };
    }
}