using System.Net;
using DailyRoutine.Shared.Infrastructure.Exceptions;
using Mailer.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
                    throw new Exception("File not found");
                }

                return await File.ReadAllBytesAsync(path, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw new DailyRoutineException(HttpStatusCode.InternalServerError, ex.Message);
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
            _logger.LogError(ex.ToString());
            throw new DailyRoutineException(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    private bool DetectPathTraversal(string fileName)
    {
        var path = _options.BasePath + Path.DirectorySeparatorChar + fileName;
        var fullPath = Path.GetFullPath(path);
        if (string.Compare(fullPath, path, StringComparison.Ordinal)!=0)
        {
            throw new DailyRoutineException(HttpStatusCode.BadRequest,"Path traversal detected");
        }
        return false;
    }
}