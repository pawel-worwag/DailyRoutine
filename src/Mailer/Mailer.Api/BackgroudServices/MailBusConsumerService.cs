using Mailer.Application.Common.Interfaces;
using Mailer.Application.Common.Messages;

namespace Mailer.Api.BackgroudServices;

public class MailBusConsumerService : IHostedService,IDisposable
{
    private readonly IMailBusConsumer _consumer;
    private readonly ILogger _logger;

    public MailBusConsumerService(IMailBusConsumer iMailBusConsumer, ILogger<MailBusConsumerService> logger)
    {
        _consumer = iMailBusConsumer;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _consumer.ConsumeMessage = ConsumeMessage;
        _consumer.Connect();
        return Task.CompletedTask;
    }

    private bool ConsumeMessage(EmailBusMessage message)
    {
        Console.WriteLine($"Sending mail '{message.Type}' to {string.Join(',',message.Recipients)}, with values: {string.Join(',',message.Values.Select(x=> $"{x.Key} = {x.Value}"))}");
        return true;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _consumer.Disconnect();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _consumer.Disconnect();
    }
}