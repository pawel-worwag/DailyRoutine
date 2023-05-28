using System.Text;
using System.Text.Json;
using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Identity.Application.Common.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;

namespace Identity.Infrastructure.Mail;

public class RabbitMqMailSender: IMailSender, IDisposable
{
    private readonly IConfiguration _conf;
    private readonly ILogger _logger;
    private ConnectionFactory? _connectionFactory = null;

    public RabbitMqMailSender(IConfiguration conf, ILogger<RabbitMqMailSender> logger)
    {
        _conf = conf;
        _logger = logger;
    }

    public async void SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values)
    {
        var cf = _connectionFactory ??= new ConnectionFactory()
        {
            HostName = _conf["MailRabbitBus:Host"],
            Port = Int32.Parse(_conf["MailRabbitBus:Port"]),
            UserName = _conf["MailRabbitBus:UserName"],
            Password = _conf["MailRabbitBus:Password"]
        };
        using var connection = cf.CreateConnection();
        using var channel = connection.CreateModel();

        var message = new EmailBusMessage()
        {
            Type =  type,
            Recipients = recipients,
            Values = values
        };

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        channel.BasicPublish(_conf["MailRabbitBus:Exchange"],_conf["MailRabbitBus:RoutingKey"],basicProperties: null,body:body);

        channel.Close(); 
        connection.Close();
    }

    public void Dispose()
    {
    }
}