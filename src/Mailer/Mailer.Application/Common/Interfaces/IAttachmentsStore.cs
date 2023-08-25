namespace Mailer.Application.Common.Interfaces;

public interface IAttachmentsStore
{
    public Task<byte[]> ReadFileAsync(string fileName, CancellationToken cancellationToken);
    public Task WriteFileAsync(string fileName, byte[] content, CancellationToken cancellationToken); 
    public Task DeleteFileAsync(string fileName, CancellationToken cancellationToken); 
}