using Proposta.Application.DTOs;
using Proposta.Domain.Enums;

namespace Proposta.Application.Interfaces;

public interface IPropostaService
{
    Task<Guid> CreateAsync(CreatePropostaDto dto, CancellationToken ct = default);
    Task<IEnumerable<PropostaDto>> ListAsync(CancellationToken ct = default);
    Task<PropostaDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task UpdateStatusAsync(Guid id, PropostaStatus novoStatus, CancellationToken ct = default);
}
