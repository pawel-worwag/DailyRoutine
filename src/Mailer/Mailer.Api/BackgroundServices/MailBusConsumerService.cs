using Mailer.Application.Common.Interfaces;
using Mailer.Application.Common.Messages;

namespace Mailer.Api.BackgroundServices;

/// <summary>
/// 
/// </summary>
public class MailBusConsumerService : IHostedService, IDisposable
{
    private readonly IMailBusConsumer _consumer;
    private readonly ILogger _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iMailBusConsumer"></param>
    /// <param name="logger"></param>
    public MailBusConsumerService(IMailBusConsumer iMailBusConsumer, ILogger<MailBusConsumerService> logger)
    {
        _consumer = iMailBusConsumer;
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _consumer.ConsumeMessage = ConsumeMessage;
        _consumer.Connect();
        return Task.CompletedTask;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private bool ConsumeMessage(EmailBusMessage message)
    {
        _logger.LogDebug("Sending mail '{type}' to {recipients}, with values: {values}", message.Type,
            string.Join(',', message.Recipients), 
            string.Join(',', message.Values.Select(x => $"{x.Key} = {x.Value}")));
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _consumer.Disconnect();
        return Task.CompletedTask;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        _consumer.Disconnect();
    }
}