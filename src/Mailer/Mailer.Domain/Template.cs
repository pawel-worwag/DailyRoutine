using System.ComponentModel.DataAnnotations.Schema;

namespace Mailer.Domain;

public class Template
{
    public int Id { get; private set; }
    public Guid Guid { get; private set; } = Guid.NewGuid();
    public EmailType Type { get; private set; } = default!;
    public Language Language { get; private set; } = default!;
    public string Subject { get; set; } = default!;
    public string BodyEncoded { get; set; } = default!;
    private HashSet<Attachment> _attachments { get; set; } = new HashSet<Attachment>();
    [NotMapped]
    public IReadOnlyCollection<Attachment> Attachments
    {
        get => _attachments;
    }

    private Template()
    {
        
    }

    public Template(EmailType type,Language language,ICollection<Attachment> attachments)
    {
        Type = type;
        Language = language;
        foreach (var attachment in attachments)
        {
            _attachments.Add(attachment);
        }
    }

    public void AddAttachment(Attachment attachment)
    {
        _attachments.Add(attachment);
    }

    public void AddAttachments(ICollection<Attachment> attachments)
    {
        foreach (var attachment in attachments)
        {
            _attachments.Add(attachment);
        }
    }
    
    public void RemoveAttachment(Attachment attachment)
    {
        _attachments.Remove(attachment);
    }
}