using Demo.API._02.Contracts;
using Demo.API._02.Utils;
using System;

namespace Demo.API._02.Services
{
    public class CalculoDeJurosService
        : ICalculoDeJuros
    {
        public decimal CalculaJurosCompostos(decimal valorInicial, int tempo, decimal taxadejuros)
        {
            var valorFinal = Decimal.ToDouble(valorInicial) * Math.Pow(Decimal.ToDouble(1 + taxadejuros), tempo);

            return TruncateValue.ToDecimal(Convert.ToDecimal(valorFinal));
        }
    }
}
