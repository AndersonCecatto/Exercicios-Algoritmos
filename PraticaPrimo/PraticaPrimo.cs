using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace PraticaPrimo
{
    class PraticaPrimo
    {
        static void Main(string[] args)
        {
            var numeros = new List<int>();
            VerificarNumeroPrimos(numeros);
        }

        private static void VerificarNumeroPrimos(IList<int> numeros)
        {
            Console.WriteLine("Informe o numero: ");
            var numero = Console.ReadLine();

            //if (!int.TryParse(numero, out _) || Convert.ToInt32(numero) < 0)
            //{
            //    Console.WriteLine("O caracter digitado não é um valor aceito!");
            //    Console.WriteLine();
            //    VerificarNumeroPrimos(numeros);
            //}

            MetodosUteis.ValidarDados(new List<string> { numero }, () => VerificarNumeroPrimos(numeros));

            var numeroConvertido = Convert.ToInt32(numero);
            var numerosListados = new List<int>();
            var inicio = 1;

            while (numeros.Count < numeroConvertido)
            {
                if (numeros.Count > 0)
                    inicio = numeros.LastOrDefault() + 1;

                numeros.Add(inicio);
            }

            if (numeros.Count > numeroConvertido)
                numerosListados = numeros.Where(x => x <= numeroConvertido).ToList();

            var iteracoes = numerosListados.Count > 0 ? numerosListados.Count(x => numeroConvertido % x == 0) : numeros.Count(x => numeroConvertido % x == 0);

            if (iteracoes == 2)
                Console.WriteLine($"O número {numeroConvertido} é primo. Número de iterações necessárias: {iteracoes}");
            else
                Console.WriteLine($"O número {numeroConvertido} não é primo. Número de iterações necessárias: {iteracoes}");

            VerificarNumeroPrimos(numeros);
        }
    }
}
