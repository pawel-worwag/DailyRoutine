using Mailer.Application.Common.Exceptions;
using Mailer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkiaSharp;
using NotSupportedException = System.NotSupportedException;

namespace Mailer.Application.Attachments.DownloadThumbnail;

public record DownloadThumbnailRequest : IRequest<Response>
{
    public required Guid Guid { get; init; }
};

internal class DownloadThumbnailHandler : IRequestHandler<DownloadThumbnailRequest, Response>
{
    private readonly IAttachmentsStore _store;
    private readonly IMailerDbContext _dbc;
    private readonly ILogger _logger;

    public DownloadThumbnailHandler(IAttachmentsStore store, IMailerDbContext dbc,
        ILogger<DownloadThumbnailHandler> logger)
    {
        _store = store;
        _dbc = dbc;
        _logger = logger;
    }

    public async Task<Response> Handle(DownloadThumbnailRequest request, CancellationToken cancellationToken)
    {
        var attachment = await _dbc.Attachments.AsNoTracking().Where(p => p.Guid == request.Guid)
            .FirstOrDefaultAsync(cancellationToken);
        if (attachment is null)
        {
            throw new NotFoundException($"Attachment {request.Guid} not found.");
        }

        var sourcePath = Path.GetTempFileName();
        var thumbnailPath = Path.GetTempFileName();

        switch (attachment.MediaType)
        {
            case "image/png":
            {
                await System.IO.File.WriteAllBytesAsync(sourcePath,
                    await _store.ReadFileAsync(attachment.Guid.ToString(), cancellationToken), cancellationToken);
                await PrepareImageThumbnail(sourcePath, thumbnailPath);

                break;
            }
            default:
            {
                await PrepareUnknownThumbnail(thumbnailPath);
                break;
            }
        }

        try
        {
            File.Delete(sourcePath);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.ToString());
        }


        return new Response
        {
            FileTempPath = thumbnailPath,
            Name = "thumb_" + attachment.Name
        };
    }

    private async Task PrepareImageThumbnail(string sourcePath, string thumbnailPath)
    {
        var bitmap = SKBitmap.Decode(sourcePath);
        var info = bitmap.Info;

        var height = (info.Height * 150) / info.Width;
        var scaled = bitmap.Resize(new SKImageInfo(150, height), SKFilterQuality.Medium);

        using var data = scaled.Encode(SKEncodedImageFormat.Png, 100);
        await using var stream = File.OpenWrite(thumbnailPath);
        data.SaveTo(stream);
    }

    private async Task PrepareUnknownThumbnail(string thumbnailPath)
    {
        var bitmap = new SKBitmap(new SKImageInfo(150, 150));
        using (var canvas = new SKCanvas(bitmap))
        {
            canvas.Clear();
            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.DarkRed;
                paint.StrokeWidth = 2;
                using (SKPath path = new SKPath())
                {
                    path.MoveTo(0, 0);
                    path.LineTo(150, 150);

                    path.MoveTo(0, 150);
                    path.LineTo(150, 0);

                    canvas.DrawPath(path, paint);
                }
            }

            using (SKPaint textPaint = new SKPaint())
            {
                string text = "No thumbnail";
                textPaint.TextSize = 20;

                SKRect bounds = new SKRect();
                textPaint.MeasureText(text, ref bounds);

                var left = (int)(75 - (bounds.Right / 2));
                if (left < 0)
                {
                    left = 0;
                }

                var top = (int)(75 - (bounds.Top / 2));
                if (top < 0)
                {
                    top = 0;
                }
                canvas.DrawText(text, left, top, textPaint);
            }
        }

        using var data = bitmap.Encode(SKEncodedImageFormat.Png, 100);
        await using var stream = File.OpenWrite(thumbnailPath);
        data.SaveTo(stream);
    }
}