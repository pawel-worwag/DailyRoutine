using Mailer.Application.Common.Interfaces;
using Mailer.Infrastructure.AttachmentsStore;
using Mailer.Infrastructure.MailBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailBusOptions>(options=>configuration.GetSection("MailRabbitBus").Bind(options));
        services.Configure<AttachmentsLocalFsStoreOptions>(options=>configuration.GetSection("AttachmentsLocalFsStore").Bind(options));
        services.AddScoped<IAttachmentsStore, AttachmentsLocalFsStore>();
        services.AddSingleton<IMailBusConsumer, MailBusConsumer>();
        return services;
    }
}