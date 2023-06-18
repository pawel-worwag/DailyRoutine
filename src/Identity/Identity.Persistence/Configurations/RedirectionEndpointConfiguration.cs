using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class RedirectionEndpointConfiguration : IEntityTypeConfiguration<Domain.Entities.RedirectionEndpoint>
{
    public void Configure(EntityTypeBuilder<RedirectionEndpoint> builder)
    {
        builder.ToTable("RedirectionEndpoints");
        builder.HasKey(p => p.Id);
        builder.Property(p=>p.Guid).IsRequired();
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Uri).IsRequired();
    }
}