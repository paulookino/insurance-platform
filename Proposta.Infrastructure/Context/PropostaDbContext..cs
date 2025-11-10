using Microsoft.EntityFrameworkCore;
using Proposta.Domain.Entities;

namespace Proposta.Infrastructure.Context
{
    public class PropostaDbContext : DbContext
    {
        public PropostaDbContext(DbContextOptions<PropostaDbContext> options)
            : base(options) { }

        public DbSet<PropostaSeguro> Propostas => Set<PropostaSeguro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PropostaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
