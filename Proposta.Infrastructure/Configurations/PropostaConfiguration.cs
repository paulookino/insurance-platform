using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proposta.Domain.Entities;

namespace Proposta.Infrastructure.Configurations
{
    public class PropostaConfiguration : IEntityTypeConfiguration<PropostaSeguro>
    {
        public void Configure(EntityTypeBuilder<PropostaSeguro> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .IsRequired();

            builder.Property(p => p.ClienteNome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Valor)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasMaxLength(20)
                   .IsRequired();
        }
    }
}
