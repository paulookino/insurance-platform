using Contratacao.Domain.Entities;
using Contratacao.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Contratacao.Infrastructure.Persistence.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly ContratacaoDbContext _context;

        public ContratoRepository(ContratacaoDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Contrato contrato)
        {
            await _context.Contratos.AddAsync(contrato);
            await _context.SaveChangesAsync();
        }

        public Task AtualizarAsync(Contrato contrato)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contrato>> ListarAsync()
        {
            return await _context.Contratos.AsNoTracking().ToListAsync();
        }

        public async Task<Contrato?> ObterPorIdAsync(Guid id)
        {
            return await _context.Contratos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
