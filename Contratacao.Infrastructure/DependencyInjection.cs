using Contratacao.Application.Interfaces;
using Contratacao.Domain.Interfaces;
using Contratacao.Infrastructure.Gateways;
using Contratacao.Infrastructure.Persistence;
using Contratacao.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;


namespace Contratacao.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContratacaoInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            // Banco de dados
            services.AddDbContext<ContratacaoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ContratacaoConnection")));

            // Repositórios
            services.AddScoped<IContratoRepository, ContratoRepository>();

            // Gateway HTTP (PropostaService)
            services.AddHttpClient<IPropostaGateway, PropostaGateway>(client =>
            {
                client.BaseAddress = new Uri(configuration["Services:PropostaApiUrl"]!);
            });

            return services;
        }
    }
}
