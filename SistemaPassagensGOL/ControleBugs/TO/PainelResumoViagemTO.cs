using SPG.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.TO
{
    public class PainelResumoViagemTO
    {

        public DateTime DataIdaEmbarque { get; set; }
        public DateTime DataIdaDesembarque { get; set; }
        public DateTime DataVoltaEmbarque { get; set; }
        public DateTime DataVoltaDesembarque { get; set; }
        public int QuantidadePassageiros { get; set; }
        public Double ValorPassagens { get; set; }
        public Double ValorTaxaEmbarque { get; set; }
        public Double ValorTotalPassagens { get; set; }

    }
}
