using Mailer.Application.Common.Interfaces;
using Mailer.Infrastructure.AttachmentsStore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AttachmentsLocalFsStoreOptions>(options=>configuration.GetSection("AttachmentsLocalFsStore").Bind(options));
        services.AddScoped<IAttachmentsStore, AttachmentsLocalFsStore>();
        return services;
    }
}