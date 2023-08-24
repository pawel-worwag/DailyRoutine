namespace Mailer.Api.Common.Options;

public static class Extensions
{
    public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MimeTypeOptions>(
            configuration.GetSection("MimeType:Allowed"));
        return services;
    }
}