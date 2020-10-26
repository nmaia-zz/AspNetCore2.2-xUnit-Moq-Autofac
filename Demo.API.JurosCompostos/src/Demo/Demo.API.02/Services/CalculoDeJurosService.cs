using Demo.API._02.Contracts;
using Demo.API._02.Utils;
using System;

namespace Demo.API._02.Services
{
    public class CalculoDeJurosService
        : ICalculoDeJuros
    {
        private readonly IApi01Request _api01Request;

        public CalculoDeJurosService(IApi01Request api01Request)
        {
            _api01Request = api01Request;
        }

        public decimal CalculaJurosCompostos(decimal valorInicial, int tempo, decimal taxadejuros)
        {
            var valorFinal = Decimal.ToDouble(valorInicial) * Math.Pow(Decimal.ToDouble(1 + taxadejuros), tempo);

            return TruncateValue.TruncateDecimal(Convert.ToDecimal(valorFinal));
        }
    }
}
