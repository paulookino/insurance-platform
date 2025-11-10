namespace Contratacao.Application.DTOs
{
    public class PropostaDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string NomeSegurado { get; set; } = string.Empty;
        public string TipoSeguro { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
