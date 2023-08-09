using Mailer.Application.Common.Messages;

namespace Mailer.Application.Common.Interfaces;

public interface IMailBusConsumer
{
    public delegate bool ProcessMessage(EmailBusMessage message);

    public void Connect();
    public void Disconnect();
    public delegate bool ConsumeMessageDelegate(EmailBusMessage message);

    public ConsumeMessageDelegate? ConsumeMessage { get; set; }
}