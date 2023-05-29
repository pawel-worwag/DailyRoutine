using System.Text;
using System.Text.Json;
using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Identity.Application.Common.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Mail;

public class RabbitMqMailSender: IMailSender, IDisposable
{
    private readonly RabbitMqMailOptions _options;
    private readonly IConfiguration _conf;
    private readonly ILogger _logger;
    private ConnectionFactory? _connectionFactory = null;

    public RabbitMqMailSender(IConfiguration conf, ILogger<RabbitMqMailSender> logger, IOptions<RabbitMqMailOptions> options)
    {
        _conf = conf;
        _logger = logger;
        _options = options.Value;
    }

    public async void SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values)
    {
        try
        {
            var cf = _connectionFactory ??= new ConnectionFactory()
            {
                HostName = _options.Host,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password
            };
            cf.Ssl.Enabled = _options.SslEnabled;
            cf.RequestedConnectionTimeout = _options.RequestedConnectionTimeout;
            using var connection = cf.CreateConnection();
            using var channel = connection.CreateModel();

            var message = new EmailBusMessage()
            {
                Type = type,
                Recipients = recipients,
                Values = values
            };

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            channel.BasicPublish(_conf["MailRabbitBus:Exchange"], _conf["MailRabbitBus:RoutingKey"],
                basicProperties: null, body: body);

            channel.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
        }
    }

    public void Dispose()
    {
    }
}