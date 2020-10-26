using Autofac.Extras.Moq;
using Demo.API._02.Contracts;
using Demo.API._02.Services;
using FluentAssertions;
using Xunit;

namespace Demo.Tests.Demo.API._02
{
    public class CalculoDeJurosTests
    {
        [Theory]
        [InlineData(100, 5, 0.01, 105.1)]
        [InlineData(450, 8, 0.01, 487.28)]
        public void CalculaJuros_Valida_Calculos_Test(decimal valorinicial, int tempo, decimal taxadejuros, decimal resultado)
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                mock.Mock<ICalculoDeJuros>()
                    .Setup(x => x.CalculaJurosCompostos(valorinicial, tempo, taxadejuros))
                    .Returns(resultado);

                var testing = mock.Create<CalculoDeJurosService>();

                var expected = resultado;

                // Act
                var actual = testing.CalculaJurosCompostos(valorinicial, tempo, taxadejuros);

                // Assert
                actual.Should().Be(expected, $"Valor difere do esperado. Valor { actual } deveria ser { expected }.");
            }
        }
    }
}
