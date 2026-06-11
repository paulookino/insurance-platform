using Contratacao.Domain.Entities;

namespace Contratacao.Domain.Ports
{
    public interface IContratacaoRepository
    {
        Task AddAsync(Contrato proposta, CancellationToken cancellationToken = default);
        Task<Contrato?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Contrato>> ListAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(Contrato proposta, CancellationToken cancellationToken = default);
    }
}
