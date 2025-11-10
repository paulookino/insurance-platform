using Microsoft.Extensions.DependencyInjection;
using Proposta.Application.Interfaces;
using Proposta.Application.Services;
using Proposta.Domain.Interfaces;
using Proposta.Infrastructure.Repositories;

namespace Proposta.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropostaDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPropostaService, PropostaService>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();

            return services;
        }
    }
}
