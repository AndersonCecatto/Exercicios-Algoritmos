using System;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public static class MetodosUteis
    {
        public static void ValidarDados(IList<string> dados, Action action)
        {
            if(dados.Any(x => !int.TryParse(x, out _) || Convert.ToInt32(x) < 0))
            {
                Console.WriteLine("O caracter digitado não é um valor aceito!");
                Console.WriteLine();

                action.Invoke();
            }
        }
    }
}
