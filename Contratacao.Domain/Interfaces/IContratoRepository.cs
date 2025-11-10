using Contratacao.Domain.Entities;

namespace Contratacao.Domain.Interfaces
{
    public interface IContratoRepository
    {
        Task<Contrato?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Contrato>> ListarAsync();
        Task AdicionarAsync(Contrato contrato);
        Task AtualizarAsync(Contrato contrato);
    }
}
