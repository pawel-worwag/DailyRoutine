namespace Mailer.Domain.Entities;

public class Template
{
    public int Id { get; set; }
    public Guid Guid { get; set; } = Guid.NewGuid();
    public EmailType Type { get; set; }
    public Language Language { get; set; }
    public string Subject { get; set; } = String.Empty;
    public string BodyEncoded { get; set; }
    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}