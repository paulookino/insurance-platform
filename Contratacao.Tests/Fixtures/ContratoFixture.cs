using Contratacao.Domain.Entities;

namespace Contratacao.Application.Tests.Fixtures;

public static class ContratoFixture
{
    public static Contrato CriarValido()
        => new Contrato(Guid.NewGuid(), "", 0, "");
}
