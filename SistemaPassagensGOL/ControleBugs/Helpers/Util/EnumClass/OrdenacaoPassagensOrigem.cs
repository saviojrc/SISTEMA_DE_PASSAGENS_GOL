using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{

    public enum OrdenacaoPassagensEnum
    {
        SELECIONE,
        MENOR_TEMPO_DE_VOO,
        TARIFA_MAIS_BAIXA,
        TARIFA_MAIS_ALTA,
        DECOLAGEM_MAIS_CEDO,
        DECOLAGEM_MAIS_TARDE,
        CHEGADA_MAIS_CEDO,
        CHEGADA_MAIS_TARDE,
        NENHUMA_DAS_OPCOES
    }
   public  class OrdenacaoPassagens
    {

        public static KeyValuePair<string, string> ObterCamposFiltroPassagens(OrdenacaoPassagensEnum OrdenacaoPassagens)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            switch (OrdenacaoPassagens)
            {
                case OrdenacaoPassagensEnum.SELECIONE:
                    dic.Add("0", "selecione");
                    break;
                case OrdenacaoPassagensEnum.MENOR_TEMPO_DE_VOO:
                    dic.Add("1", "menor tempo de voo");
                    break;
                case OrdenacaoPassagensEnum.TARIFA_MAIS_BAIXA:
                    dic.Add("2", "tarifa mais baixa");
                    break;
                case OrdenacaoPassagensEnum.TARIFA_MAIS_ALTA:
                    dic.Add("3", "tarifa mais alta");
                    break;
                case OrdenacaoPassagensEnum.DECOLAGEM_MAIS_CEDO:
                    dic.Add("4", "decolagem mais cedo");
                    break;
                case OrdenacaoPassagensEnum.DECOLAGEM_MAIS_TARDE:
                    dic.Add("5", "decolagem mais tarde ");
                    break;
                case OrdenacaoPassagensEnum.CHEGADA_MAIS_CEDO:
                    dic.Add("6", "chegada mais cedo");
                    break;
                case OrdenacaoPassagensEnum.CHEGADA_MAIS_TARDE:
                    dic.Add("7", "chegada  mais tarde");
                    break;
                case OrdenacaoPassagensEnum.NENHUMA_DAS_OPCOES:
                    dic.Add("8", "nenhuma das opções");
                    break;
               
            }

            return dic.First();
        }
    }
}
