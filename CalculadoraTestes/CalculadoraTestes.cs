using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTestes
{
    public CalculadoraImp classe()
        {
            string data = new DateTime().ToString();
            CalculadoraImp calc = new CalculadoraImp(data);

            return calc;
        }        

        [Theory]
        [InlineData (2,3,5)]
        [InlineData (8,5,13)]
        public void somarDoisNumeros(int valor1, int valor2, int resultado)
        {
            CalculadoraImp calc = classe();
            int resultaoSoma = calc.Somar(valor1, valor2);
            Assert.Equal(resultado, resultaoSoma);
        }

        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(8, 5, 3)]
        public void subtrairDoisNumeros(int valor1, int valor2, int resultado)
        {
            CalculadoraImp calc = classe();
            int resultaoSubtracao = calc.Subtrair(valor1, valor2);
            Assert.Equal(resultado, resultaoSubtracao);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(8, 5, 40)]
        public void multiplicarDoisNumeros(int valor1, int valor2, int resultado)
        {
            CalculadoraImp calc = classe();
            int resultaoMultiplicacao = calc.Multiplicar(valor1, valor2);
            Assert.Equal(resultado, resultaoMultiplicacao);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(9, 3, 3)]
        public void dividirDoisNumeros(int valor1, int valor2, int resultado)
        {
            CalculadoraImp calc = classe();
            int resultaoDivisao = calc.Dividir(valor1, valor2);
            Assert.Equal(resultado, resultaoDivisao);
        }

        [Fact]
        public void dividirNumeroPor0()
        {
            CalculadoraImp calc = classe();
            Assert.Throws<DivideByZeroException>(
            () => calc.Dividir(6,0)
            );
        }

        [Fact]
        public void testeHistorico()
        {
            CalculadoraImp calc = classe();
            calc.Somar(1, 2);
            calc.Somar(3, 4);
            calc.Somar(4, 5);
            calc.Somar(5, 6);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
}