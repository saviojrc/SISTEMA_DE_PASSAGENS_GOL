using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{

    public enum HorariosViagemEnum
    {
        EMBARQUE,
        DESEMBARQUE
    }

    public class HorariosViagem
    {
        public static KeyValuePair<TipoElementoEnum, string> ObterCamposHorariosViagem(HorariosViagemEnum HorariosViagem)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (HorariosViagem)
            {
                case HorariosViagemEnum.EMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, "#ida");
                    break;
                case HorariosViagemEnum.DESEMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, "#volta");
                    break;
              

            }

            return dic.First();
        }

    }
}
