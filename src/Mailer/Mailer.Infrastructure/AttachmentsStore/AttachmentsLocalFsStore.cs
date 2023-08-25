using System.Net;
using Mailer.Application.Common.Interfaces;
using Mailer.Infrastructure.Common.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IOException = Mailer.Infrastructure.Common.Exceptions.IOException;

namespace Mailer.Infrastructure.AttachmentsStore;

public class AttachmentsLocalFsStore : IAttachmentsStore
{
    private readonly AttachmentsLocalFsStoreOptions _options;
    private readonly ILogger _logger;

    public AttachmentsLocalFsStore(IOptions<AttachmentsLocalFsStoreOptions> options, ILogger<AttachmentsLocalFsStore> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    public async Task<byte[]> ReadFileAsync(string fileName, CancellationToken cancellationToken)
    {
            DetectPathTraversal(fileName);
            try
            {
                var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
                if (!File.Exists(path))
                {
                    throw new NotFoundException("File not found");
                }

                return await File.ReadAllBytesAsync(path, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message,ex);
            }
    }

    public async Task WriteFileAsync(string fileName, byte[] content, CancellationToken cancellationToken)
    {
        DetectPathTraversal(fileName);
        try
        {
            var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
            await File.WriteAllBytesAsync(path, content, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new IOException( ex.Message,ex);
        }
    }

    public async Task DeleteFileAsync(string fileName, CancellationToken cancellationToken)
    {
        DetectPathTraversal(fileName);
        try
        {
            var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
            File.Delete(path);
        }
        catch (Exception ex)
        {
            throw new IOException( ex.Message,ex);
        }

        await Task.CompletedTask;
    }

    private bool DetectPathTraversal(string fileName)
    {
        var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
        var fullPath = Path.GetFullPath(path);
        if (string.Compare(fullPath, path, StringComparison.Ordinal)!=0)
        {
            throw new PathTraversalException("Path traversal detected");
        }
        return false;
    }
}