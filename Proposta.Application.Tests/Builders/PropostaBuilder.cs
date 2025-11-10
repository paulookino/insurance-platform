using Proposta.Domain.Enums;
using Proposta.Domain.ValueObjects;

namespace Proposta.Application.Tests.Builders
{
    public class PropostaBuilder
    {
        private string _nomeSegurado = "João da Silva";
        private decimal _valor = 1000;
        private string _tipoSeguro = "Auto";
        private List<Cobertura> _coberturas= new List<Cobertura>();
        private PropostaStatus _status = PropostaStatus.EmAnalise;

        public PropostaBuilder ComNome(string nome)
        {
            _nomeSegurado = nome;
            return this;
        }

        public PropostaBuilder ComValor(decimal valor)
        {
            _valor = valor;
            return this;
        }

        public PropostaBuilder ComTipo(string tipo)
        {
            _tipoSeguro = tipo;
            return this;
        }

        public PropostaBuilder ComStatus(PropostaStatus status)
        {
            _status = status;
            return this;
        }

        public Domain.Entities.PropostaSeguro Build()
        {
            return new Domain.Entities.PropostaSeguro(_nomeSegurado, _valor, _coberturas);
        }
    }
}
