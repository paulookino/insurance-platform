namespace Contratacao.Domain.Entities
{
    public class Contrato
    {
        public Guid Id { get; private set; }
        public Guid PropostaId { get; private set; }
        public DateTime DataContratacao { get; private set; }
        public decimal Valor { get; private set; }
        public string TipoSeguro { get; private set; }
        public string NomeSegurado { get; private set; }
        public string Status { get; private set; }

        protected Contrato() { }

        public Contrato(Guid propostaId, string nomeSegurado, decimal valor, string tipoSeguro)
        {
            if (propostaId == Guid.Empty)
                throw new ArgumentException("PropostaId inválido.");

            Id = Guid.NewGuid();
            PropostaId = propostaId;
            NomeSegurado = nomeSegurado;
            Valor = valor;
            TipoSeguro = tipoSeguro;
            DataContratacao = DateTime.UtcNow;
            Status = "Ativo";
        }

        public void Cancelar()
        {
            if (Status == "Cancelado")
                throw new InvalidOperationException("Contrato já está cancelado.");

            Status = "Cancelado";
        }
    }
}
