using Contratacao.Application.Interfaces;
using Contratacao.Application.UseCases;
using Contratacao.Domain.Entities;
using Contratacao.Domain.Interfaces;

namespace Contratacao.Application.Tests.UseCases;

public class ContratarPropostaHandlerTests
{
    private readonly Mock<IPropostaGateway> _propostaGatewayMock;
    private readonly Mock<IContratoRepository> _contratoRepoMock;
    private readonly ContratarPropostaHandler _handler;

    public ContratarPropostaHandlerTests()
    {
        _propostaGatewayMock = new Mock<IPropostaGateway>();
        _contratoRepoMock = new Mock<IContratoRepository>();
        _handler = new ContratarPropostaHandler(_contratoRepoMock.Object, _propostaGatewayMock.Object);
    }

    [Fact(DisplayName = "Deve contratar proposta aprovada com sucesso")]
    public async Task Deve_Contratar_Proposta_Aprovada_Com_Sucesso()
    {
        // Arrange
        var propostaId = Guid.NewGuid();
        _propostaGatewayMock.Setup(g => g.ObterPropostaAsync(propostaId))
            .ReturnsAsync(new DTOs.PropostaDto());

        var comando = new DTOs.ContratarPropostaRequest();

        // Act
        var resultado = await _handler.HandleAsync(comando);

        // Assert
        _contratoRepoMock.Verify(r => r.AdicionarAsync(It.IsAny<Contrato>()), Times.Once);
    }

    [Fact(DisplayName = "Não deve contratar proposta rejeitada")]
    public async Task Nao_Deve_Contratar_Proposta_Rejeitada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();
        _propostaGatewayMock.Setup(g => g.ObterPropostaAsync(propostaId))
            .ReturnsAsync(new DTOs.PropostaDto());

        var comando = new DTOs.ContratarPropostaRequest();

        // Act
        Func<Task> act = async () => await _handler.HandleAsync(comando);

        // Assert
        
        _contratoRepoMock.Verify(r => r.AdicionarAsync(It.IsAny<Contrato>()), Times.Never);
    }
}
