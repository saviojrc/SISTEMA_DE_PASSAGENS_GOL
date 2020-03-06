using System.Collections.Generic;
using System.Linq;

namespace SPG.Helpers.Util.EnumClass
{

    public enum TipoOrdenacaoPrecoEnum
    {

        ORIGEM,
        DESTINO
    }


    public class TipoOrdenacaoPreco
    {

        public static KeyValuePair<TipoElementoEnum, string> ObterCamposFiltroPassagens(TipoOrdenacaoPrecoEnum TipoOrdenacaoPreco)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (TipoOrdenacaoPreco)
            {
                case TipoOrdenacaoPrecoEnum.DESTINO:
                    dic.Add(TipoElementoEnum.Id, "ControlGroupSelect2View_AvailabilityInputSelect2View_DropDownListSortCriteriaMkt2Crit1");
                    break;
                case TipoOrdenacaoPrecoEnum.ORIGEM:
                    dic.Add(TipoElementoEnum.Id, "ControlGroupSelect2View_AvailabilityInputSelect2View_DropDownListSortCriteriaMkt1Crit1");
                    break;
             
            }

            return dic.First();
        }
    }
}
