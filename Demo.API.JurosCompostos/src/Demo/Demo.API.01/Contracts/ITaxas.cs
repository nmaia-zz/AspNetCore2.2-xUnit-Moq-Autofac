using System.Threading.Tasks;

namespace Demo.API._01.Contracts
{
    public interface ITaxas
    {
        Task<decimal> RetornaTaxaDeJuros();
    }
}
