using Proposta.Domain.Entities;

namespace Proposta.Domain.Interfaces;

public interface IPropostaRepository
{
    Task<PropostaSeguro?> ObterPorIdAsync(Guid id);
    Task<List<PropostaSeguro>> ListarAsync();
    Task AdicionarAsync(PropostaSeguro proposta);
    Task AtualizarAsync(PropostaSeguro proposta);
}
