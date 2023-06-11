using System.Net.Mail;

namespace Mailer.Application.Common.Interfaces;

public interface IMailClient
{
    Task SendDemoAsync(CancellationToken cancellationToken);
}