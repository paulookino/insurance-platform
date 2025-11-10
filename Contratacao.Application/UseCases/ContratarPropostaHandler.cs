using Contratacao.Application.DTOs;
using Contratacao.Application.Interfaces;
using Contratacao.Domain.Entities;
using Contratacao.Domain.Interfaces;

namespace Contratacao.Application.UseCases
{
    public class ContratarPropostaHandler
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IPropostaGateway _propostaGateway;

        public ContratarPropostaHandler(
            IContratoRepository contratoRepository,
            IPropostaGateway propostaGateway)
        {
            _contratoRepository = contratoRepository;
            _propostaGateway = propostaGateway;
        }

        public async Task<ContratoResponse> HandleAsync(Contratacao.Application.DTOs.ContratarPropostaRequest request)
        {
            var proposta = await _propostaGateway.ObterPropostaAsync(request.PropostaId);
            if (proposta is null)
                throw new InvalidOperationException("Proposta não encontrada.");

            if (!string.Equals(proposta.Status, "Aprovada", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("A proposta não está aprovada.");

            var contrato = new Contrato(
                propostaId: request.PropostaId,
                nomeSegurado: request.NomeSegurado,
                valor: request.Valor,
                tipoSeguro: request.TipoSeguro
            );

            await _contratoRepository.AdicionarAsync(contrato);

            return new ContratoResponse
            {
                Id = contrato.Id,
                PropostaId = contrato.PropostaId,
                NomeSegurado = contrato.NomeSegurado,
                TipoSeguro = contrato.TipoSeguro,
                Valor = contrato.Valor,
                Status = contrato.Status,
                DataContratacao = contrato.DataContratacao
            };
        }
    }
}
