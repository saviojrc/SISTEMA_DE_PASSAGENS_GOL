using System;

namespace SPG.TO
{
    public class TabelaResumoViagemTO
    {

        public int Indice { get; set; }
        public DateTime HorarioIda { get; set; }
        public string Origem { get; set; }
        public DateTime Duracao { get; set; }
        public DateTime HorarioVolta { get; set; }
        public string Destino { get; set; }
        public ValoresTarifasTO ValoresTarifasTO { get; set; }

    }
}
