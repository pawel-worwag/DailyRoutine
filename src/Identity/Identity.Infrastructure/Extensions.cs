using Identity.Application.Common.Interfaces;
using Identity.Infrastructure.Mail;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<RabbitMqMailOptions>(options=>configuration.GetSection("MailRabbitBus").Bind(options));
        //services.AddScoped<IMailBusProducer, RabbitMqMailBusProducer>();

        RabbitMqMailOptions rabbitOptions = new(); 
        configuration.GetSection("MailRabbitBus").Bind(rabbitOptions);
        
        services.AddOptions<RabbitMqTransportOptions>()
            .Configure(options =>
            {
                options.Host = rabbitOptions.Host;
                options.Port = (ushort)rabbitOptions.Port;
                options.VHost = "/";
                options.User = rabbitOptions.UserName;
                options.Pass = rabbitOptions.Password;
                options.UseSsl = rabbitOptions.SslEnabled;
            });
        
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Publish<Identity.Infrastructure.Mail.Messages.SendMailMessage>(x =>
                {
                    x.Durable = true;
                    x.AutoDelete = true;
                    x.ExchangeType = "topic";
                });
            });
        });
        
        
        services.AddScoped<IMailBusProducer, MassTransitMailBus>();
        return services;
    }
}