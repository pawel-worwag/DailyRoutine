using Mailer.Application.Common.Enums;

namespace Mailer.Application.Common.Messages;

public record EmailBusMessage
{
    public EmailType Type { get; init; } = EmailType.UNKNOWN;
    public ICollection<string> Recipients { get; init; } = new List<string>();
    public IDictionary<string, string> Values { get; init; } = new Dictionary<string, string>();
}