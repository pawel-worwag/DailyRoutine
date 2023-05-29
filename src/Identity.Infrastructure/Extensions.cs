using Identity.Application.Common.Interfaces;
using Identity.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqMailOptions>(options=>configuration.GetSection("MailRabbitBus").Bind(options));
        services.AddScoped<IMailSender, RabbitMqMailSender>();
        return services;
    }
}