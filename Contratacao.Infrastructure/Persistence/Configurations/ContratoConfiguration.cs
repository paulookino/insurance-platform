using Contratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacao.Infrastructure.Persistence.Configurations
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeSegurado)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.TipoSeguro)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.Valor);

            builder.Property(c => c.DataContratacao)
                   .IsRequired();
        }
    }
}
