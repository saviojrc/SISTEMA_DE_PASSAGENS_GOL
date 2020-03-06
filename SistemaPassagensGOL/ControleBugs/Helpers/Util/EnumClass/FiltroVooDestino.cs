using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{

    public enum FiltroVooDestinoEnum
    {
        FILTRO,
        CANCELAR,
        PRECOS_ATE,
        PARADAS,
        PARTIDAS,
        CHEGADAS,
        FILTRAR
    }

    public class FiltroVooDestino
    {

        public static KeyValuePair<TipoElementoEnum, string> ObterCamposFiltroPassagens(FiltroVooDestinoEnum FiltroVooDestinoEnum)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (FiltroVooDestinoEnum)
            {
                case FiltroVooDestinoEnum.FILTRO:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersClosed > input");
                    break;
                case FiltroVooDestinoEnum.CANCELAR:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersOptions > div.flightFiltersOptionsConfirm > input.flightFiltersOptionsConfirmText.flightFiltersOptionsCancel");
                    break;
                case FiltroVooDestinoEnum.PRECOS_ATE:
                    dic.Add(TipoElementoEnum.Id, "selectPrices2");
                    break;
                case FiltroVooDestinoEnum.PARADAS:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersOptions > div.flightFiltersOptionsBody > div.flightFiltersOptionsBodyPartition.flightFiltersOptionsBodyPartitionStops");
                    break;
                case FiltroVooDestinoEnum.PARTIDAS:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersOptions > div.flightFiltersOptionsBody > div.flightFiltersOptionsBodyPartition.flightFiltersOptionsBodyPartitionDepartureTime");
                    break;
                case FiltroVooDestinoEnum.CHEGADAS:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersOptions > div.flightFiltersOptionsBody > div.flightFiltersOptionsBodyPartition.flightFiltersOptionsBodyPartitionArrivalTime");
                    break;
                case FiltroVooDestinoEnum.FILTRAR:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter02 > div.flightFiltersOptions > div.flightFiltersOptionsConfirm > input.flightFiltersOptionsConfirmButton");
                    break;

            }

            return dic.First();
        }

    }
}
