using Contratacao.Application.DTOs;

namespace Contratacao.Application.Interfaces
{
    public interface IPropostaGateway
    {
        Task<PropostaDto?> ObterPropostaAsync(Guid propostaId);
    }
}
