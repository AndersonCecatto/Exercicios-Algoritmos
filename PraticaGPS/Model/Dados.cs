using System.Collections.Generic;

namespace PraticaGPS.Model
{
    public class Dados : BaseDados
    {
        public int NumeroCidades { get; set; }
        public IList<Cidade> Cidades { get; set; }
        public int NumeroEstradas { get; set; }
        public IList<PontoCidade> PontosCidades { get; set; }
        public string CidadePartida { get; set; }
        public string CidadeDestino { get; set; }
    }
}
