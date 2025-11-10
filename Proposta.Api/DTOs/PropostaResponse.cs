namespace Proposta.Api.DTOs
{
    public class PropostaResponse
    {
        public Guid Id { get; set; }
        public string NomeSegurado { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string TipoSeguro { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }
}
