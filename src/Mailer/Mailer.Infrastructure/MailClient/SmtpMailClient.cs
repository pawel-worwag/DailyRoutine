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

    public async Task SendDemoAsync(CancellationToken cancellationToken)
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
        await smtp.SendAsync(PrepareDummyMail(), cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }

    private MimeMessage PrepareDummyMail()
    {
        var mail = new MimeMessage();
        
        mail.From.Add(new MailboxAddress(_options.DisplayName, _options.From));
        mail.Sender = new MailboxAddress(_options.DisplayName, _options.From);
        mail.To.Add(MailboxAddress.Parse("pawel.worwag@gmail.com"));
        var body = new BodyBuilder();
        mail.Subject = "[MailKit] Mail test";
        body.HtmlBody = "<html><body><h1>HELLO</h1><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec ligula a elit malesuada dapibus eget ac lectus. Aenean ac varius dui. Vestibulum tincidunt ante mauris, eget aliquam lectus pellentesque a. In hac habitasse platea dictumst. Phasellus lacus lectus, imperdiet vitae rhoncus vitae, imperdiet a mauris. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam condimentum sagittis bibendum. Praesent id euismod sem. Nunc iaculis nulla neque, nec eleifend elit feugiat sit amet. Curabitur at est nibh.</p></body></html>";
        mail.Body = body.ToMessageBody();
        return mail;
    }
}