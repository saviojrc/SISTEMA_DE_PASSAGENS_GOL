using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{

    public enum PainelResumoPassagemEnum
    {
        PAINEL,
        DATA_IDA,
        HORARIO_EMBARQUE_IDA,
        HORARIO_DESEMBARQUE_IDA,
        DATA_VOLTA,
        HORARIO_EMBARQUE_VOLTA,
        HORARIO_DESEMBARQUE_VOLTA,
        QUANTIDADE_PASSAGEIROS,
        VALOR_PASSAGENS,
        VALOR_TAXA_EMBARQUE,
        VALOR_TOTAL_PASSAGENS,
        COMPRAR

    }
   public  class PainelResumoPassagem
    {
        public static KeyValuePair<TipoElementoEnum, string> ObterPainelResumoPassagem(PainelResumoPassagemEnum PainelResumoPassagem)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (PainelResumoPassagem)
            {
                case PainelResumoPassagemEnum.PAINEL:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo");
                    break;
                case PainelResumoPassagemEnum.DATA_IDA:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-journey > div:nth-child(2) > div.flight-date");
                    break;
                case PainelResumoPassagemEnum.HORARIO_EMBARQUE_IDA:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-journey > div:nth-child(2) > div:nth-child(2)");
                    break;
                case PainelResumoPassagemEnum.HORARIO_DESEMBARQUE_IDA:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-journey > div:nth-child(2) > div:nth-child(4)");
                    break;
                case PainelResumoPassagemEnum.DATA_VOLTA:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-journey > div:nth-child(4) > div.flight-date");
                    break;
                case PainelResumoPassagemEnum.HORARIO_EMBARQUE_VOLTA:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-journey > div:nth-child(4) > div:nth-child(2)");
                    break;
                case PainelResumoPassagemEnum.HORARIO_DESEMBARQUE_VOLTA:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-journey > div:nth-child(4) > div:nth-child(4)");
                    break;
                case PainelResumoPassagemEnum.QUANTIDADE_PASSAGEIROS:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-details > div.fare-details > div.row.adt > div.text");
                    break;
                case PainelResumoPassagemEnum.VALOR_PASSAGENS:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-details > div.fare-details > div.row.adt > div.value");
                    break;
                case PainelResumoPassagemEnum.VALOR_TAXA_EMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-details > div.fare-details > div:nth-child(2) > div.value");
                    break;
                case PainelResumoPassagemEnum.VALOR_TOTAL_PASSAGENS:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > div.banner-details > div.fare-details > div:nth-child(4) > div.value");
                    break;
                case PainelResumoPassagemEnum.COMPRAR:
                    dic.Add(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > button");
                    break;
            }

            return dic.First();
        }

    }
}
