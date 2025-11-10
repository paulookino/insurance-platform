using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proposta.Domain.Interfaces;
using Proposta.Infrastructure.Context;
using Proposta.Infrastructure.Repositories;

namespace Proposta.Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddPropostaInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        services.AddDbContext<PropostaDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IPropostaRepository, PropostaRepository>();

        return services;
    }
}
