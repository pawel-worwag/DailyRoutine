using Identity.Application.Common.Enums;

namespace Identity.Infrastructure.Mail.Messages;

public record SendMailMessage
{
    public required string Type { get; init; }
    public required string Language { get; init; }
    public required ICollection<string> Recipients { get; init; }
    public required IDictionary<string, string> Values { get; init; }
}