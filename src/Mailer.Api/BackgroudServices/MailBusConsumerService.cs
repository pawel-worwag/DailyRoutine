using Mailer.Application.Common.Interfaces;

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
        _consumer.Connect();
        return Task.CompletedTask;
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