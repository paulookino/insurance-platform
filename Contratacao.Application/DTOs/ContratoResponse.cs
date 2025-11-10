namespace Contratacao.Application.DTOs
{
    public class ContratoResponse
    {
        public Guid Id { get; set; }
        public Guid PropostaId { get; set; }
        public string NomeSegurado { get; set; } = string.Empty;
        public string TipoSeguro { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
    }
}
