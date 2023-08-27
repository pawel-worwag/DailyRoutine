using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Identity.Infrastructure.Common.Exceptions;
using Identity.Infrastructure.Mail.Messages;
using MassTransit;

namespace Identity.Infrastructure.Mail;

public class MassTransitMailBus : IMailBusProducer
{
    public readonly IPublishEndpoint _endpoints;

    public MassTransitMailBus(IPublishEndpoint publishEndpoint)
    {
        _endpoints = publishEndpoint;
    }

    public async Task SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values)
    {
        try
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await _endpoints.Publish<SendMailMessage>(new SendMailMessage
            {
                Type = MapToString(type),
                Language = "en",
                Recipients = recipients,
                Values = values
            }, source.Token);
        }
        catch (TaskCanceledException ex)
        {
            throw new MailBusException("Cannot send email.",ex);
        }
    }

    private string MapToString(EmailType type)
    {
        switch(type)
        {
            case EmailType.HELLO:
            {
                return "confirm-email";
            }
            case EmailType.RESTORE_PASSWORD:
            {
                return "restore-password";
            }
            default: return "unknown";
        }
    }
}