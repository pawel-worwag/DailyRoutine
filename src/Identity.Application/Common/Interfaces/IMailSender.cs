using Identity.Application.Common.Enums;

namespace Identity.Application.Common.Interfaces;

public interface IMailSender
{
    void SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values);
}