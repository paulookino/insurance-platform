using Proposta.Domain.Enums;

namespace Proposta.Api.DTOs
{
    public class AtualizarStatusRequest
    {
        public PropostaStatus NovoStatus { get; set; }
    }
}
