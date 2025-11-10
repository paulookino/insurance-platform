using Proposta.Domain.Enums;
using Proposta.Domain.Exceptions;
using Proposta.Domain.ValueObjects;

namespace Proposta.Domain.Entities;

public class PropostaSeguro
{
    public Guid Id { get; private set; }
    public string ClienteNome { get; private set; } = default!;
    public decimal Valor { get; private set; }
    public List<Cobertura> Coberturas { get; private set; } = new();
    public PropostaStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected PropostaSeguro() { }

    public PropostaSeguro(string clienteNome, decimal valor, IEnumerable<Cobertura> coberturas)
    {
        if (string.IsNullOrWhiteSpace(clienteNome))
            throw new DomainException("O nome do cliente é obrigatório.");

        if (valor <= 0)
            throw new DomainException("O valor da proposta deve ser maior que zero.");

        Id = Guid.NewGuid();
        ClienteNome = clienteNome;
        Valor = valor;
        Coberturas = coberturas?.ToList() ?? new List<Cobertura>();
        Status = PropostaStatus.EmAnalise;
        CreatedAt = DateTime.UtcNow;
    }

    public void AtualizarStatus(PropostaStatus novoStatus)
    {
        if (Status == PropostaStatus.Aprovada || Status == PropostaStatus.Rejeitada)
            throw new DomainException("Não é possível alterar o status de uma proposta finalizada.");

        Status = novoStatus;
    }
}
