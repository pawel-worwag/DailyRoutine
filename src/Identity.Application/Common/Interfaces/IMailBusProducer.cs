using Identity.Application.Common.Enums;

namespace Identity.Application.Common.Interfaces;

public interface IMailBusProducer
{
    Task SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values);
}