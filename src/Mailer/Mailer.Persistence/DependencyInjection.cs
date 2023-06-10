using Mailer.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Persistence;

public static class DependencyInjection
{
   public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContextPool<MailerDbContext>(options =>
         options.UseNpgsql(configuration.GetConnectionString("MailerDatabase")));
      services.AddScoped<IMailerDbContext, MailerDbContext>();
      return services;
   }
}