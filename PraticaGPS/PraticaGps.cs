using PraticaGPS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PraticaGPS
{
    class PraticaGps
    {
        static void Main(string[] args)
        {

            var retorno = GpsFitSolution(@"C:\Users\Anderson\Desktop\Teste\2- FIT - EntradaGPS.txt");

            foreach (var item in retorno)
                Console.WriteLine(item);
        }

        private static List<Dados> ReadFile(string filePath)
        {
            string[] conteudo = File.ReadAllLines(filePath);
            var casosTeste = Convert.ToInt32(conteudo[0]);

            var dados = new List<Dados>();

            for (int i = 1; i < conteudo.Length; i++)
            {
                if (conteudo[i] == string.Empty)
                    continue;

                var dado = new Dados
                {
                    CasosTeste = casosTeste,
                    NumeroCidades = Convert.ToInt32(conteudo[i]),
                    NumeroEstradas = Convert.ToInt32(conteudo[i + 2])
                };

                dado.Cidades = new List<Cidade>();
                dado.PontosCidades = new List<PontoCidade>();

                foreach (var item in conteudo[i + 1].Trim().Split(' '))
                {
                    dado.Cidades.Add(new Cidade { Nome = item });
                }


                for (int y = 1; y <= 4; y++)
                {
                    var conteudoCidades = conteudo[i + 2 + y].Split(' ');

                    dado.PontosCidades.Add(new PontoCidade
                    {
                        CidadePontaEstrada = conteudoCidades[0],
                        CidadeOutroLadoEstrada = conteudoCidades[1],
                        Tempo = Convert.ToInt32(conteudoCidades[2])
                    });
                }

                var cidadePartidadaDestino = conteudo[i + 7].Split(' ');

                dado.CidadePartida = cidadePartidadaDestino[0];
                dado.CidadeDestino = cidadePartidadaDestino[1];

                dados.Add(dado);
                i += 7;
            }

            return dados;
        }

        private static List<int> GpsFitSolution(string filePath)
        {
            var dados = ReadFile(filePath);
            var tempos = new List<int>();

            foreach (var dado in dados)
            {
                var tempo = 0;

                var retorno = dado.PontosCidades.FirstOrDefault(x => x.CidadePontaEstrada == dado.CidadePartida && x.CidadeOutroLadoEstrada == dado.CidadeDestino);

                if (retorno is null)
                {
                    foreach (var ponto in dado.PontosCidades)
                    {
                        if (dado.CidadePartida == ponto.CidadePontaEstrada && dado.CidadeDestino == ponto.CidadeOutroLadoEstrada)
                        {
                            dado.CidadePartida = ponto.CidadeOutroLadoEstrada;
                            tempo += ponto.Tempo;
                            break;
                        }
                        else if (dado.CidadePartida == ponto.CidadePontaEstrada && dado.CidadeDestino != ponto.CidadeOutroLadoEstrada)
                        {
                            dado.CidadePartida = ponto.CidadeOutroLadoEstrada;
                            tempo += ponto.Tempo;
                        }
                    }
                }
                else
                    tempo += retorno.Tempo;

                tempos.Add(tempo);
            }

            return tempos;
        }
    }
}
