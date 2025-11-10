using Bogus;

namespace Proposta.Application.Tests
{
    public abstract class TestBase
    {
        protected readonly Faker Faker;

        protected TestBase()
        {
            Faker = new Faker("pt_BR");
        }
    }
}
