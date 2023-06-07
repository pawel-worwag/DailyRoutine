using System.Net;
using System.Text;
using System.Text.Json;
using DailyRoutine.Shared.Infrastructure.Exceptions;
using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Identity.Application.Common.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Microsoft.Extensions.Options;

namespace Identity.Infrastructure.Mail;

public class RabbitMqMailSender : IMailSender
{
    private readonly RabbitMqMailOptions _options;
    private readonly ILogger _logger;

    public RabbitMqMailSender(IOptions<RabbitMqMailOptions> options, ILogger<RabbitMqMailSender> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    public async Task SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values)
    {
        try
        {
            var cf = new ConnectionFactory
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
            
            using var connection = cf.CreateConnection();
            using var channel = connection.CreateModel();

            var message = new EmailBusMessage()
            {
                Type = type,
                Recipients = recipients,
                Values = values
            };
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(_options.Exchange, _options.RoutingKey, basicProperties: null, body: body);
            _logger.LogInformation(json);

            channel.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            throw new DailyRoutineException(HttpStatusCode.InternalServerError, ex.Message);
        }
        await Task.CompletedTask;
    }
}