using Demo.API._01.Contracts;
using System.Threading.Tasks;

namespace Demo.API._01.Services
{
    public class TaxaDeJurosService
        : ITaxas
    {
        public async Task<decimal> RetornaTaxaDeJuros()
        {
            return await Task.Run(() => { return 0.01M; });
        }
    }
}
