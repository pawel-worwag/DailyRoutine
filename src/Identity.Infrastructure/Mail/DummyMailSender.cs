using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Identity.Infrastructure.Mail;

public class DummyMailSender : IMailSender
{
    private readonly ILogger<DummyMailSender> _logger;

    public DummyMailSender(ILogger<DummyMailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendMailAsync(EmailType type, ICollection<string> recipients, IDictionary<string, string> values)
    {
        _logger.LogInformation($"Sending mail '{type}' to {string.Join(',',recipients)}, with values: {string.Join(',',values.Select(x=> $"{x.Key} = {x.Value}"))}");
        await Task.CompletedTask;
    }
}