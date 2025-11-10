using Moq;
using Proposta.Application.DTOs;
using Proposta.Application.Services;
using Proposta.Domain.Entities;
using Proposta.Domain.Interfaces;
using Proposta.Domain.ValueObjects;
using Xunit;

public class PropostaServiceTests
{
    [Fact]
    public async Task CreateAsync_Deve_Criar_Proposta_Com_Status_EmAnalise()
    {
        // Arrange
        var repoMock = new Mock<IPropostaRepository>();
        var service = new PropostaService(repoMock.Object);

        var dto = new CreatePropostaDto
        {
            ClienteNome = "João",
            Valor = 1500,
            Coberturas = new List<CoberturaDto>
            {
                new() { Tipo = "Roubo", ValorCoberto = 1000 }
            }
        };

        // Act
        var id = await service.CreateAsync(dto);

        // Assert
        repoMock.Verify(r => r.AddAsync(It.Is<Propostas>(p =>
            p.ClienteNome == "João" &&
            p.Status == Proposta.Domain.Enums.PropostaStatus.EmAnalise
        ), default), Times.Once);
    }
}
