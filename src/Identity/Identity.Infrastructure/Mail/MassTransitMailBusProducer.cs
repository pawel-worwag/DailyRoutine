using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Identity.Infrastructure.Mail.Messages;
using MassTransit;

namespace Identity.Infrastructure.Mail;

public class MassTransitMailBusProducer : IMailBusProducer
{
    private readonly IBus _bus;

    public MassTransitMailBusProducer(IBus bus)
    {
        _bus = bus;
    }

    public async Task SendMailAsync(EmailType type,string language,  ICollection<string> recipients, IDictionary<string, string> values)
    {
        var sendEndpoint = await _bus.GetPublishSendEndpoint<SendMailCommand>();
        var message = new SendMailCommand()
        {
            Type = type,
            Language = language,
            Recipients = recipients,
            Values = values
        };
        await sendEndpoint.Send<SendMailCommand>(message);
    }
}