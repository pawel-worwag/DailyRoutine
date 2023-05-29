namespace Identity.Infrastructure.Mail;

public class RabbitMqMailOptions
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 5672;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public string RoutingKey { get; set; } = string.Empty;
    public bool SslEnabled { get; set; } = false;
    public TimeSpan RequestedConnectionTimeout { get; set; } = new TimeSpan(0, 0, 0, 5);
}