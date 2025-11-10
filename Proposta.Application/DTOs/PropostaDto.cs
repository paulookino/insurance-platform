using Proposta.Domain.Enums;

namespace Proposta.Application.DTOs;

public class PropostaDto
{
    public Guid Id { get; set; }
    public string ClienteNome { get; set; } = default!;
    public decimal Valor { get; set; }
    public List<CoberturaDto> Coberturas { get; set; } = new();
    public PropostaStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
