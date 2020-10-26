namespace Demo.API._02.Contracts
{
    public interface ICalculoDeJuros
    {
        decimal CalculaJurosCompostos(decimal valorInicial, int tempo, decimal taxadejuros);
    }
}
