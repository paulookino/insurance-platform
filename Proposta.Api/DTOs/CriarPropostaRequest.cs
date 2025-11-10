namespace Proposta.Api.DTOs
{
    public class CriarPropostaRequest
    {
        public string NomeSegurado { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string TipoSeguro { get; set; } = string.Empty;
    }
}
