using Proposta.Application.DTOs;
using Proposta.Application.Interfaces;
using Proposta.Domain.Entities;
using Proposta.Domain.Enums;
using Proposta.Domain.Exceptions;
using Proposta.Domain.Interfaces;
using Proposta.Domain.ValueObjects;

namespace Proposta.Application.Services;

public class PropostaService : IPropostaService
{
    private readonly IPropostaRepository _repository;

    public PropostaService(IPropostaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(CreatePropostaDto dto, CancellationToken ct = default)
    {
        var coberturas = dto.Coberturas.Select(c => new Cobertura(c.Tipo, c.ValorCoberto));
        var proposta = new PropostaSeguro(dto.ClienteNome, dto.Valor, coberturas);

        await _repository.AdicionarAsync(proposta);
        return proposta.Id;
    }

    public async Task<IEnumerable<PropostaDto>> ListAsync(CancellationToken ct = default)
    {
        var propostas = await _repository.ListarAsync();
        return propostas.Select(MapToDto);
    }

    public async Task<PropostaDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var proposta = await _repository.ObterPorIdAsync(id);
        return proposta == null ? null : MapToDto(proposta);
    }

    public async Task UpdateStatusAsync(Guid id, PropostaStatus novoStatus, CancellationToken ct = default)
    {
        var proposta = await _repository.ObterPorIdAsync(id)
            ?? throw new DomainException("Proposta não encontrada.");

        proposta.AtualizarStatus(novoStatus);
        await _repository.AtualizarAsync(proposta);
    }

    private static PropostaDto MapToDto(PropostaSeguro proposta)
        => new()
        {
            Id = proposta.Id,
            ClienteNome = proposta.ClienteNome,
            Valor = proposta.Valor,
            Status = proposta.Status,
            CreatedAt = proposta.CreatedAt,
            Coberturas = proposta.Coberturas.Select(c => new CoberturaDto
            {
                Tipo = c.Tipo,
                ValorCoberto = c.ValorCoberto
            }).ToList()
        };
}
