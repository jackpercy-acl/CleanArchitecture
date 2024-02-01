using CleanArchitecture.Domain.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.EntityFramework.Configurations.Generators;

internal sealed class GeneratorConfiguration : IEntityTypeConfiguration<Generator>
{
    public void Configure(EntityTypeBuilder<Generator> builder)
    {
        builder
            .HasMany(g => g.Assets)
            .WithOne(a => a.Generator)
            .HasForeignKey(a => a.GeneratorId)
            .IsRequired();
    }
}