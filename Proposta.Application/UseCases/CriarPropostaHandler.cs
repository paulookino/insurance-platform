using Proposta.Domain.Entities;
using Proposta.Domain.Interfaces;
using Proposta.Domain.ValueObjects;

namespace Proposta.Application.UseCases
{
    public class CriarPropostaHandler
    {
        private readonly IPropostaRepository _repo;
        public CriarPropostaHandler(IPropostaRepository repo) => _repo = repo;

        public async Task<Guid> HandleAsync(string cliente, decimal valor, IEnumerable<Cobertura> coberturas,CancellationToken ct = default)
        {
            var proposta = new PropostaSeguro(cliente, valor, coberturas);
            await _repo.AdicionarAsync(proposta);
            return proposta.Id;
        }
    }

}
