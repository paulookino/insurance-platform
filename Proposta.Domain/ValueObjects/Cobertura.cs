namespace Proposta.Domain.ValueObjects
{
    public class Cobertura
    {
        public string Tipo { get; private set; } = default!;
        public decimal ValorCoberto { get; private set; }

        protected Cobertura() { }

        public Cobertura(string tipo, decimal valorCoberto)
        {
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("O tipo de cobertura é obrigatório.");

            if (valorCoberto <= 0)
                throw new ArgumentException("O valor coberto deve ser maior que zero.");

            Tipo = tipo;
            ValorCoberto = valorCoberto;
        }
    }

}
