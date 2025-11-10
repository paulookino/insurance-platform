using Contratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contratacao.Infrastructure.Persistence
{
    public class ContratacaoDbContext : DbContext
    {
        public ContratacaoDbContext(DbContextOptions<ContratacaoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contrato> Contratos => Set<Contrato>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContratacaoDbContext).Assembly);
        }
    }
}
