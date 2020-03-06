using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{
    public enum FiltroVooOrigemEnum
    {

        FILTRO,
        CANCELAR,
        PRECOS_ATE,
        PARADAS,
        PARTIDAS,
        CHEGADAS,
        FILTRAR
    }


    public class FiltroVooOrigem
    {

        public static KeyValuePair<TipoElementoEnum, string> ObterCamposFiltroPassagens(FiltroVooOrigemEnum FiltroVooOrigemEnum)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (FiltroVooOrigemEnum)
            {
                case FiltroVooOrigemEnum.FILTRO:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersClosed > input");
                    break;
                case FiltroVooOrigemEnum.CANCELAR:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersOptions > div.flightFiltersOptionsConfirm > input.flightFiltersOptionsConfirmText.flightFiltersOptionsCancel");
                    break;
                case FiltroVooOrigemEnum.PRECOS_ATE:
                    dic.Add(TipoElementoEnum.Id, "selectPrices1");
                    break;
                case FiltroVooOrigemEnum.PARADAS:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersOptions > div.flightFiltersOptionsBody > div.flightFiltersOptionsBodyPartition.flightFiltersOptionsBodyPartitionStops");
                    break;
                case FiltroVooOrigemEnum.PARTIDAS:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersOptions > div.flightFiltersOptionsBody > div.flightFiltersOptionsBodyPartition.flightFiltersOptionsBodyPartitionDepartureTime");
                    break;
                case FiltroVooOrigemEnum.CHEGADAS:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersOptions > div.flightFiltersOptionsBody > div.flightFiltersOptionsBodyPartition.flightFiltersOptionsBodyPartitionArrivalTime");
                    break;
                case FiltroVooOrigemEnum.FILTRAR:
                    dic.Add(TipoElementoEnum.CssSelector, "#flightsFilter01 > div.flightFiltersOptions > div.flightFiltersOptionsConfirm > input.flightFiltersOptionsConfirmButton");
                    break;
            }

            return dic.First();
        }
    }
}
