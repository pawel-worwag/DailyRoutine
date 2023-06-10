using System.Text;
using System.Text.Json;
using Mailer.Application.Common.Interfaces;
using Mailer.Application.Common.Messages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Mailer.Infrastructure.MailBus;

public class MailBusConsumer : IMailBusConsumer, IDisposable
{
    private readonly MailBusOptions _options;
    private IConnection? _connection = null;
    private IModel? _channel = null;
    private EventingBasicConsumer? _consumer = null;
    private ILogger _logger;
    public IMailBusConsumer.ConsumeMessageDelegate ConsumeMessage { get; set; }
    
    public MailBusConsumer(IOptions<MailBusOptions> options, ILogger<MailBusConsumer> logger)
    {
        _logger = logger;
        _options = options.Value;
    }
    public void Connect()
    {
        var factory = new ConnectionFactory
        {
            HostName = _options.Host,
            Port = _options.Port,
            UserName = _options.UserName,
            Password = _options.Password,
            Ssl =
            {
                Enabled = _options.SslEnabled
            },
            RequestedConnectionTimeout = _options.RequestedConnectionTimeout
        };
        
        if (_connection is not null && _connection.IsOpen)
        {
            throw new Exception("Already connected");
        }
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _consumer = new EventingBasicConsumer(_channel);
        _consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var messageStr = Encoding.UTF8.GetString(body);
            var message = JsonSerializer.Deserialize<EmailBusMessage>(messageStr);

            if (ConsumeMessage?.Invoke(message) == true)
            {
                _channel.BasicAck(ea.DeliveryTag,false);
            }
            else
            {
                _logger.LogError("Cannot consume message '{delivery}' from exchange '{queue}'",ea.DeliveryTag,ea.Exchange);
                _channel.BasicNack(ea.DeliveryTag,false,true);
                Thread.Sleep(3000);
            }
        };
        _channel.BasicConsume(_options.Queue, false, _consumer);
    }
    
    
    public void Disconnect()
    {
        if (_channel is not null)
        {
            _channel.Close();
            _channel.Dispose();
            _channel = null;
        }
        if (_connection is not null)
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }


    public void Dispose()
    {
        this.Disconnect();
    }
}