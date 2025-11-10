using Contratacao.Application.DTOs;
using Contratacao.Domain.Interfaces;

namespace Contratacao.Application.UseCases
{
    public class ListarContratosHandler
    {
        private readonly IContratoRepository _contratoRepository;

        public ListarContratosHandler(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        public async Task<IEnumerable<ContratoResponse>> HandleAsync()
        {
            var contratos = await _contratoRepository.ListarAsync();

            return contratos.Select(c => new ContratoResponse
            {
                Id = c.Id,
                PropostaId = c.PropostaId,
                NomeSegurado = c.NomeSegurado,
                TipoSeguro = c.TipoSeguro,
                Valor = c.Valor,
                Status = c.Status,
                DataContratacao = c.DataContratacao
            });
        }
    }
}
