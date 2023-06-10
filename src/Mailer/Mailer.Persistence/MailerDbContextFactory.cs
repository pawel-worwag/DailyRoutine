using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mailer.Persistence;

public class MailerDbContextFactory : IDesignTimeDbContextFactory<MailerDbContext>
{
    private const string ConnectionStringName = "MailerDatabase";
    private const string AspNetCoreEnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
    
    public MailerDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        var environmentName = Environment.GetEnvironmentVariable(AspNetCoreEnvironmentVariableName);
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        var connectionString = configuration.GetConnectionString(ConnectionStringName);
        var optionsBuilder = new DbContextOptionsBuilder<MailerDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new MailerDbContext(optionsBuilder.Options);
    }
}