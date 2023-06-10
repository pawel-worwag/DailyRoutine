using System.Net;
using Mailer.Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace Mailer.Infrastructure.AttachmentsStore;

public class AttachmentsLocalFsStore : IAttachmentsStore
{
    private readonly AttachmentsLocalFsStoreOptions _options;

    public AttachmentsLocalFsStore(IOptions<AttachmentsLocalFsStoreOptions> options)
    {
        _options = options.Value;
    }

    public async Task<byte[]> ReadFileAsync(string fileName, CancellationToken cancellationToken)
    {
        DetectPathTraversal(fileName);
        var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
        if (!File.Exists(path))
        {
            throw new Exception("File not found");
        }
        return await File.ReadAllBytesAsync(path, cancellationToken);
    }

    public async Task WriteFileAsync(string fileName, byte[] content, CancellationToken cancellationToken)
    {
        DetectPathTraversal(fileName);
        var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
        await File.WriteAllBytesAsync(path, content, cancellationToken);
    }

    private bool DetectPathTraversal(string fileName)
    {
        var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
        var fullPath = Path.GetFullPath(path);
        if (string.Compare(fullPath, path, StringComparison.Ordinal)!=0)
        {
            throw new Exception("Path traversal detected");
        }
        return false;
    }
}