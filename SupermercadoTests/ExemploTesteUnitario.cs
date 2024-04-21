using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupermercadoTests
{
    public class ExemploTesteUnitario
    {
        // Fact é para informa que este é um cenário de teste
        [Fact]
        public void Test_CalculadoraSomar_NumerosPositivos()
        {
            // Arrange (constrói tudo que é necessário para poder realizar o ato do teste)
            var minhaCalculadora = new Calculadora();

            // Act (executar o ato do teste)
            var resultado = minhaCalculadora.Somar(20, 30);

            // Assert (validar que a execução fez o que era esperado
            Assert.Equal(50, resultado);
        }

        [Fact]
        public void Test_CalculadoraSomar_NumeroPositivoENegativo()
        {
            // Arrange
            var minhaCalculadora = new Calculadora();

            // Act
            var resultado = minhaCalculadora.Somar(-20, 30);

            // Assert
            Assert.Equal(10, resultado);
        }

        [Fact]
        public void Test_CalculadoraSomar_NumerosNegativos()
        {
            // Arrange
            var minhaCalculadora = new Calculadora();

            // Act
            var resultado = minhaCalculadora.Somar(-20, -5);

            // Assert
            Assert.Equal(-25, resultado);
        }
    }

    class Calculadora
    {
        public int Somar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }
    }
}
