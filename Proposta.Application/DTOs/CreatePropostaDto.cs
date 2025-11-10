namespace Proposta.Application.DTOs;

public class CreatePropostaDto
{
    public string ClienteNome { get; set; } = default!;
    public decimal Valor { get; set; }
    public List<CoberturaDto> Coberturas { get; set; } = new();
}

public class CoberturaDto
{
    public string Tipo { get; set; } = default!;
    public decimal ValorCoberto { get; set; }
}
