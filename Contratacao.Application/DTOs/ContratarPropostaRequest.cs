using System.ComponentModel.DataAnnotations;

namespace Contratacao.Application.DTOs
{
    public class ContratarPropostaRequest
    {
        [Required]
        public Guid PropostaId { get; set; }

        [Required, MaxLength(200)]
        public string NomeSegurado { get; set; } = default!;

        [Required, MaxLength(100)]
        public string TipoSeguro { get; set; } = default!;

        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }
    }
}
