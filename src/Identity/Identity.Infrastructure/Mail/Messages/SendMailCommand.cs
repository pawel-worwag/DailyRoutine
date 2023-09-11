using Identity.Application.Common.Enums;
using MassTransit;

namespace Identity.Infrastructure.Mail.Messages;

[MessageUrn("SendMailCommand")]
public record SendMailCommand
{
    public required EmailType Type { get; init; }
    public required string Language { get; init; }
    public required ICollection<string> Recipients { get; init; }
    public required IDictionary<string, string> Values { get; init; }
}