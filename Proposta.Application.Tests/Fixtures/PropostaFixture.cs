using Proposta.Domain.Entities;
using Proposta.Domain.ValueObjects;

namespace Proposta.Application.Tests.Fixtures;

public static class PropostaFixture
{
    public static Domain.Entities.PropostaSeguro CriarValida()
        => new("Teste", 1, new List<Cobertura>());
}
