using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proposta.Domain.ValueObjects;

namespace Proposta.Infrastructure.Configurations;

public class CoberturaConfiguration : IEntityTypeConfiguration<Cobertura>
{
    public void Configure(EntityTypeBuilder<Cobertura> builder)
    {
        builder.Property(c => c.Tipo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ValorCoberto)
            .HasPrecision(18, 2)
            .IsRequired();
    }
}
