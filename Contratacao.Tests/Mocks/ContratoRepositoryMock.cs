using Contratacao.Domain.Entities;
using Contratacao.Domain.Interfaces;
using Moq;

namespace Contratacao.Application.Tests.Mocks
{
    public static class ContratoRepositoryMock
    {
        public static Mock<IContratoRepository> CriarMock()
        {
            var mock = new Mock<IContratoRepository>();
            mock.Setup(x => x.AdicionarAsync(It.IsAny<Contrato>()))
                .Returns(Task.CompletedTask);
            mock.Setup(x => x.ListarAsync())
                .ReturnsAsync(new List<Contrato>());
            return mock;
        }
    }
}
