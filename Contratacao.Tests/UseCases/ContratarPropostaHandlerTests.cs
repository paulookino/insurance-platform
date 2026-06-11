using Contratacao.Application.DTOs;
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

        _propostaGatewayMock
            .Setup(g => g.ObterPropostaAsync(propostaId))
            .ReturnsAsync(new PropostaDto
            {
                Id = propostaId,
                Status = "Aprovada",
                NomeSegurado = "João Silva",
                TipoSeguro = "Vida",
                Valor = 1000m
            });

        var comando = new ContratarPropostaRequest
        {
            PropostaId = propostaId,
            NomeSegurado = "João Silva",
            TipoSeguro = "Vida",
            Valor = 1000m
        };

        // Act
        var resultado = await _handler.HandleAsync(comando);

        // Assert
        resultado.Should().NotBeNull();
        resultado.PropostaId.Should().Be(propostaId);
        _contratoRepoMock.Verify(r => r.AdicionarAsync(It.IsAny<Contrato>()), Times.Once);
    }

    [Fact(DisplayName = "Não deve contratar proposta rejeitada")]
    public async Task Nao_Deve_Contratar_Proposta_Rejeitada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();

        _propostaGatewayMock
            .Setup(g => g.ObterPropostaAsync(propostaId))
            .ReturnsAsync(new PropostaDto
            {
                Id = propostaId,
                Status = "Rejeitada",
                NomeSegurado = "João Silva",
                TipoSeguro = "Vida",
                Valor = 1000m
            });

        var comando = new ContratarPropostaRequest
        {
            PropostaId = propostaId,
            NomeSegurado = "João Silva",
            TipoSeguro = "Vida",
            Valor = 1000m
        };

        // Act
        Func<Task> act = async () => await _handler.HandleAsync(comando);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*aprovada*");
        _contratoRepoMock.Verify(r => r.AdicionarAsync(It.IsAny<Contrato>()), Times.Never);
    }

    [Fact(DisplayName = "Deve lançar exceção quando proposta não encontrada")]
    public async Task Deve_Lancar_Excecao_Quando_Proposta_Nao_Encontrada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();

        _propostaGatewayMock
            .Setup(g => g.ObterPropostaAsync(propostaId))
            .ReturnsAsync((PropostaDto?)null);

        var comando = new ContratarPropostaRequest
        {
            PropostaId = propostaId,
            NomeSegurado = "João Silva",
            TipoSeguro = "Vida",
            Valor = 1000m
        };

        // Act
        Func<Task> act = async () => await _handler.HandleAsync(comando);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*Proposta não encontrada*");
    }
}
