using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Configurations;

public class ClientConfiguration:IEntityTypeConfiguration<Domain.Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Guid).IsUnique();
        builder.Property(p => p.Guid).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.HasMany(p => p.RedirectionEndpoints).WithOne(p => p.Client).HasForeignKey(p => p.ClientId);
    }
}