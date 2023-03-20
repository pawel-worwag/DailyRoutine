using System.Reflection;
using Mailer.Application.Common.Interfaces;
using Mailer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Persistence;

public class MailerDbContext : DbContext, IMailerDbContext
{
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<EmailType> EmailTypes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Template> Templates { get; set; }

    public MailerDbContext(DbContextOptions<MailerDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}