using Mailer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mailer.Application.CustomExtensions;

public static class TemplateExtensions
{
    public static IQueryable<Template> WithAllIncludes(this DbSet<Template> source)
    {
        return source.Include("_attachments")
            .Include(p => p.Language)
            .Include(p => p.Type);
    }
}