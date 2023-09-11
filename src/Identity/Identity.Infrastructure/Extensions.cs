using Identity.Application.Common.Interfaces;
using Identity.Infrastructure.Mail;
using Identity.Infrastructure.Mail.Messages;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<RabbitMqTransportOptions>()
            .Configure(options =>
            {
                options.Host = configuration.GetValue<string>("Rabbit:Host");
                options.Port = configuration.GetValue<ushort>("Rabbit:Port");
                options.VHost = configuration.GetValue<string>("Rabbit:VHost");
                options.User = configuration.GetValue<string>("Rabbit:User");
                options.Pass = configuration.GetValue<string>("Rabbit:Pass");
                options.UseSsl = configuration.GetValue<bool>("Rabbit:UseSsl");
            });
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Message<SendMailCommand>(c =>
                {
                    c.SetEntityName("SendMail");
                });
            });
        });
        services.AddScoped<IMailBusProducer, MassTransitMailBusProducer>();
        return services;
    }
}