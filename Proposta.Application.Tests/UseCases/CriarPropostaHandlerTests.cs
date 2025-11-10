using Proposta.Application.UseCases;
using Proposta.Domain.Interfaces;
using Proposta.Domain.ValueObjects;

namespace Proposta.Application.Tests.UseCases;

public class CriarPropostaHandlerTests
{
    private readonly Mock<IPropostaRepository> _repoMock;
    private readonly CriarPropostaHandler _handler;

    public CriarPropostaHandlerTests()
    {
        _repoMock = new Mock<IPropostaRepository>();
        _handler = new CriarPropostaHandler(_repoMock.Object);
    }

    [Fact(DisplayName = "Deve criar proposta com sucesso")]
    public async Task Deve_Criar_Proposta_Com_Sucesso()
    {
        // Arrange
        
        // Act
        var proposta = await _handler.HandleAsync("João da Silva", 1200.50m, new List<Cobertura>(), CancellationToken.None);

        // Assert
        proposta.Should().NotBeEmpty();

        _repoMock.Verify(r => r.AdicionarAsync(It.IsAny<Proposta.Domain.Entities.PropostaSeguro>()), Times.Once);
    }
}
