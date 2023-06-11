using Mailer.Application.Common.Interfaces;
using Mailer.Infrastructure.AttachmentsStore;
using Mailer.Infrastructure.MailBus;
using Mailer.Infrastructure.MailClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailBusOptions>(options=>configuration.GetSection("MailRabbitBus").Bind(options));
        services.Configure<AttachmentsLocalFsStoreOptions>(options=>configuration.GetSection("AttachmentsLocalFsStore").Bind(options));
        
        services.Configure<SmtpOptions>(options=>configuration.GetSection("SmtpServer").Bind(options));
        
        services.AddScoped<IAttachmentsStore, AttachmentsLocalFsStore>();
        services.AddSingleton<IMailBusConsumer, MailBusConsumer>();
        services.AddScoped<IMailClient, SmtpMailClient>();
        return services;
    }
}