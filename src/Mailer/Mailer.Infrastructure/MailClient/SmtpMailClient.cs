using System.Net.Mail;
using Mailer.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Mailer.Infrastructure.MailClient;

public class SmtpMailClient : IMailClient
{
    private readonly SmtpOptions _options;

    public SmtpMailClient(IOptions<SmtpOptions> options)
    {
        _options = options.Value;
    }

    public async Task SendAsync(MailData mail, CancellationToken cancellationToken)
    {
        using var smtp = new SmtpClient();
        if (_options.UseSsl)
        {
            await smtp.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.SslOnConnect, cancellationToken);
        }
        else if (_options.UseStartTls)
        {
            await smtp.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.StartTls, cancellationToken);
        }
        
        await smtp.AuthenticateAsync(_options.UserName, _options.Password, cancellationToken);
        await smtp.SendAsync(PrepareMail(mail), cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }
    
    private MimeMessage PrepareMail(MailData data)
    {
        var mail = new MimeMessage();
        
        mail.From.Add(new MailboxAddress(_options.DisplayName, _options.From));
        mail.Sender = new MailboxAddress(_options.DisplayName, _options.From);
        foreach (var address in data.To)
        {
            mail.To.Add(MailboxAddress.Parse(address));
        }
        mail.Subject = data.Subject;
        var body = new BodyBuilder
        {
            HtmlBody = data.Body
        };
        mail.Body = body.ToMessageBody();
        return mail;
    }
}