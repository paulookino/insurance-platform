using Microsoft.EntityFrameworkCore;
using Proposta.Domain.Entities;
using Proposta.Domain.Interfaces;
using Proposta.Infrastructure.Context;

namespace Proposta.Infrastructure.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly PropostaDbContext _context;

        public PropostaRepository(PropostaDbContext context)
        {
            _context = context;
        }

        public async Task<PropostaSeguro?> ObterPorIdAsync(Guid id)
        {
            return await _context.Propostas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PropostaSeguro>> ListarAsync()
        {
            return await _context.Propostas.AsNoTracking().ToListAsync();
        }

        public async Task AdicionarAsync(PropostaSeguro proposta)
        {
            await _context.Propostas.AddAsync(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(PropostaSeguro proposta)
        {
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }
    }
}
