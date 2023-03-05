using System.Net.Mime;

namespace Mailer.Domain.Entities;

public class Attachment
{
    public Guid Guid { get; set; }
    public string Path { get; set; } = String.Empty;
    public string MediaType { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public bool Inline { get; set; } = true;
}