using Moq;
using Proposta.Application.DTOs;
using Proposta.Application.Interfaces;
using Proposta.Application.Services;
using Proposta.Domain.Entities;
using Proposta.Domain.Enums;
using Proposta.Domain.Interfaces;
using Proposta.Application.Tests.Builders;
using Proposta.Api.DTOs;

namespace Proposta.Application.Tests.Services
{
    public class PropostaServiceTests : TestBase
    {
        private readonly Mock<IPropostaRepository> _repoMock;
        private readonly IPropostaService _service;

        public PropostaServiceTests()
        {
            _repoMock = new Mock<IPropostaRepository>();
            _service = new PropostaService(_repoMock.Object);
        }

        [Fact(DisplayName = "Deve criar proposta com sucesso")]
        public async Task CriarProposta_DeveCriarComSucesso()
        {
            // Arrange
            var request = new CreatePropostaDto
            {
                ClienteNome = Faker.Person.FullName,
                Valor = 5000
            };

            _repoMock.Setup(r => r.AdicionarAsync(It.IsAny<PropostaSeguro>()));

            // Act
            var result = await _service.CreateAsync(request, default);

            // Assert
            result.Should().NotBeEmpty();

            _repoMock.Verify(r => r.AdicionarAsync(It.IsAny<PropostaSeguro>()), Times.Once);
        }

        [Fact(DisplayName = "Deve retornar todas as propostas")]
        public async Task Listar_DeveRetornarLista()
        {
            // Arrange
            var propostas = new List<PropostaSeguro>
            {
                new PropostaBuilder().ComNome("Maria").Build(),
                new PropostaBuilder().ComNome("José").Build()
            };

            _repoMock.Setup(r => r.ListarAsync()).ReturnsAsync(propostas);

            // Act
            var result = await _service.ListAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Select(p => p.ClienteNome).Should().Contain(new[] { "Maria", "José" });
        }

        [Fact(DisplayName = "Deve atualizar status da proposta para Aprovada")]
        public async Task AtualizarStatus_DeveAtualizarComSucesso()
        {
            // Arrange
            var proposta = new PropostaBuilder().ComStatus(PropostaStatus.EmAnalise).Build();

            _repoMock.Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
                     .ReturnsAsync(proposta);

            _repoMock.Setup(r => r.AtualizarAsync(It.IsAny<PropostaSeguro>()))
                     .Returns(Task.CompletedTask);

            // Act
            await _service.UpdateStatusAsync(proposta.Id, PropostaStatus.Aprovada, default);

            // Assert
            proposta.Status.Should().Be(PropostaStatus.Aprovada);
            _repoMock.Verify(r => r.AtualizarAsync(It.IsAny<PropostaSeguro>()), Times.Once);
        }
    }
}
