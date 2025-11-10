using Contratacao.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Contratacao.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContratacaoApplication(this IServiceCollection services)
        {
            services.AddScoped<ContratarPropostaHandler>();
            services.AddScoped<ListarContratosHandler>();

            return services;
        }
    }
}
