using Autofac.Extras.Moq;
using Demo.API._01.Contracts;
using Demo.API._01.Services;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class TaxaJuros_Tests
    {
        [Fact]
        public async Task TaxaJuros_Valida_Valor_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                mock.Mock<ITaxas>()
                    .Setup(x => x.RetornaTaxaDeJuros())
                    .ReturnsAsync(0.01M);

                var testing = mock.Create<TaxaDeJurosService>();

                var expected = 0.01M;

                // Act
                var actual = await testing.RetornaTaxaDeJuros();

                // Assert
                actual.Should().Be(expected, $"Valor difere do esperado. Valor { actual } deveria ser { expected }.");
            }
        }
    }
}
