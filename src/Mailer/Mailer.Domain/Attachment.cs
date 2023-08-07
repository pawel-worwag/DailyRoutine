using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace Mailer.Domain;

public class Attachment
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MediaType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Inline { get; set; } = true;
    
    private HashSet<Template> _templates { get; set; } = new HashSet<Template>();
    [NotMapped]
    public IReadOnlyCollection<Template> Templates {
        get => _templates;
    }
}