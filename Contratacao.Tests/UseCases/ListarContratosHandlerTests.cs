using Contratacao.Application.Tests.Mocks;
using Contratacao.Application.UseCases;
using Contratacao.Domain.Entities;

namespace Contratacao.Application.Tests.UseCases
{
    public class ListarContratosHandlerTests
    {
        [Fact(DisplayName = "Deve retornar lista de contratos existentes")]
        public async Task Deve_Retornar_Lista_Contratos()
        {
            // Arrange
            var contratoRepo = ContratoRepositoryMock.CriarMock();
            contratoRepo.Setup(x => x.ListarAsync())
                .ReturnsAsync(new List<Contrato>
                {
                    new(Guid.NewGuid(), "João", 1, "1000"),
                    new(Guid.NewGuid(), "Maria", 1, "2000")
                });

            var handler = new ListarContratosHandler(contratoRepo.Object);

            // Act
            var result = await handler.HandleAsync();

            // Assert
            result.Any();
        }
    }
}
