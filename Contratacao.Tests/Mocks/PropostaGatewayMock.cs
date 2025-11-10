using Contratacao.Application.DTOs;
using Contratacao.Application.Interfaces;
using Moq;

namespace Contratacao.Application.Tests.Mocks
{
	public static class PropostaGatewayMock
	{
		public static Mock<IPropostaGateway> CriarMockPropostaAprovada()
		{
			var mock = new Mock<IPropostaGateway>();
			mock.Setup(x => x.ObterPropostaAsync(It.IsAny<Guid>()))
				.ReturnsAsync(new PropostaDto
				{
					Id = Guid.NewGuid(),
					Status = "Aprovada",
					NomeSegurado = "João Silva",
					TipoSeguro = "Auto",
					Valor = 1500
				});

			return mock;
		}

		public static Mock<IPropostaGateway> CriarMockPropostaPendente()
		{
			var mock = new Mock<IPropostaGateway>();
			mock.Setup(x => x.ObterPropostaAsync(It.IsAny<Guid>()))
				.ReturnsAsync(new PropostaDto
				{
					Id = Guid.NewGuid(),
					Status = "Pendente",
					NomeSegurado = "João Silva",
					TipoSeguro = "Auto",
					Valor = 1500
				});

			return mock;
		}

		public static Mock<IPropostaGateway> CriarMockPropostaInexistente()
		{
			var mock = new Mock<IPropostaGateway>();
			mock.Setup(x => x.ObterPropostaAsync(It.IsAny<Guid>()))
				.ReturnsAsync((PropostaDto?)null);

			return mock;
		}
	}
}
