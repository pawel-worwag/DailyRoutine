using Mailer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.Common.Interfaces;

public interface IMailerDbContext
{
    DbSet<Attachment> Attachments { get; set; }
    DbSet<EmailType> EmailTypes { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<Template> Templates { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}