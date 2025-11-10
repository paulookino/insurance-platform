using Microsoft.EntityFrameworkCore;
using Proposta.Application.UseCases;
using Proposta.Infrastructure;
using Proposta.Infrastructure.Repositories;

namespace Proposta.Tests
{
    public class CriarPropostaTests
    {
        [Fact]
        public async Task CriarProposta_DevePersistir_IdNaoVazio()
        {
            // arrange - usar InMemoryDbContext ou um repository fake
            var options = new DbContextOptionsBuilder<PropostaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using var ctx = new PropostaDbContext(options);
            var repo = new PropostaRepository(ctx);
            var handler = new CriarPropostaHandler(repo);

            // act
            var id = await handler.HandleAsync("João", 1000m);

            // assert
            var persisted = await ctx.Propostas.FindAsync(id);
            Assert.NotNull(persisted);
            Assert.Equal("João", persisted.ClienteNome);
        }
    }

}
