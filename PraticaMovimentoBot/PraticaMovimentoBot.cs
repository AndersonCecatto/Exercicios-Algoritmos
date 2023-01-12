using System;
using System.Collections.Generic;
using Util;

namespace PraticaMovimentoBot
{
    class PraticaMovimentoBot
    {
        static void Main(string[] args)
        {
            MovimentoBot();
        }

        private static void MovimentoBot()
        {
            Console.WriteLine("Informe coordenada X inicial: ");
            var coordenadaX_inicial = Console.ReadLine();

            Console.WriteLine("Informe coordenada Y inicial: ");
            var coordenadaY_inicial = Console.ReadLine();

            Console.WriteLine("Informe coordenada X Final: ");
            var coordenadaX_final = Console.ReadLine();

            Console.WriteLine("Informe coordenada Y Final: ");
            var coordenadaY_final = Console.ReadLine();

            var coodernadas = new List<string> { coordenadaX_inicial, coordenadaY_inicial, coordenadaX_final, coordenadaY_final };

            MetodosUteis.ValidarDados(coodernadas, () => MovimentoBot());

            var coordenadaX_inicial_Convertida = Convert.ToInt32(coordenadaX_inicial);
            var coordenadaY_inicial_Convertida = Convert.ToInt32(coordenadaY_inicial);
            var coordenadaX_final_Convertida = Convert.ToInt32(coordenadaX_final);
            var coordenadaY_final_Convertida = Convert.ToInt32(coordenadaY_final);


            for (int y = coordenadaY_inicial_Convertida; y < coordenadaY_final_Convertida; y = coordenadaY_inicial_Convertida)
                coordenadaY_inicial_Convertida += coordenadaX_inicial_Convertida;

            for (int x = coordenadaX_inicial_Convertida; x < coordenadaX_final_Convertida; x = coordenadaX_inicial_Convertida)
                coordenadaX_inicial_Convertida += coordenadaY_inicial_Convertida;


            /// Esse FUNCIONOU
            //for (int y = coordenadaY_inicial_Convertida; y < coordenadaY_final_Convertida; y = coordenadaY_inicial_Convertida)
            //{
            //    coordenadaY_inicial_Convertida += coordenadaX_inicial_Convertida;

            //    for (int x = coordenadaX_inicial_Convertida; x < coordenadaX_final_Convertida; x = coordenadaX_inicial_Convertida)
            //    {
            //        coordenadaX_inicial_Convertida += coordenadaY_inicial_Convertida;
            //    }
            //}

            if (coordenadaX_inicial_Convertida == coordenadaX_final_Convertida && coordenadaY_inicial_Convertida == coordenadaY_final_Convertida)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);

            //Console.WriteLine(coordenadaX_inicial_Convertida);
            //Console.WriteLine(coordenadaY_inicial_Convertida);

            MovimentoBot();
        }

    }
}
