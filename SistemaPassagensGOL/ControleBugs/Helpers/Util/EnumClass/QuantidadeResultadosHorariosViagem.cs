using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{

    public enum QuantidadeResultadosHorariosViagemEnum {
        EMBARQUE,
        DESEMBARQUE

    }
    public class QuantidadeResultadosHorariosViagem
    {
        public static KeyValuePair<TipoElementoEnum, string> ObterCamposFiltroPassagens(QuantidadeResultadosHorariosViagemEnum QuantidadeResultadosHorariosViagem)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (QuantidadeResultadosHorariosViagem)
            {
                case QuantidadeResultadosHorariosViagemEnum.EMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersClosed > h3 > span.numberFlights");
                    break;
                case QuantidadeResultadosHorariosViagemEnum.DESEMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersClosed > h3 > span.numberFlights");
                    break;
              

            }

            return dic.First();
        }

    }
}
