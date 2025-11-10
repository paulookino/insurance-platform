using System.Net.Http.Json;
using Contratacao.Application.DTOs;
using Contratacao.Application.Interfaces;

namespace Contratacao.Infrastructure.Gateways
{
    public class PropostaGateway : IPropostaGateway
    {
        private readonly HttpClient _httpClient;

        public PropostaGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PropostaDto?> ObterPropostaAsync(Guid propostaId)
        {
            var response = await _httpClient.GetAsync($"/api/propostas/{propostaId}");
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PropostaDto>();
        }
    }
}
