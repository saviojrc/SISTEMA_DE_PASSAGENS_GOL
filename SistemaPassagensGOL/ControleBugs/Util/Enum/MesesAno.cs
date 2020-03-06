using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Util.Enum
{


    public enum MesesAnoEnum
    {
        JANEIRO,
        FEVEREIRO,
        MARCO,
        ABRIL,
        MAIO,
        JUNHO,
        JULHO,
        AGOSTO,
        SETEMBRO,
        OUTUBRO,
        NOVEMBRO,
        DEZEMBRO
    }
    public class MesesAno
    {

        public static KeyValuePair<MesesAnoEnum, int> ObterMes(string Mes)
        {
            Dictionary<MesesAnoEnum, int> dic = new Dictionary<MesesAnoEnum, int>();
            Mes = Utilitarios.VerificarStringValida(Mes) ? Mes.Trim() : "";
            switch (Mes)
            {
                case "Janeiro":
                    dic.Add(MesesAnoEnum.JANEIRO, 01);
                    break;
                case "Fevereiro":
                    dic.Add(MesesAnoEnum.FEVEREIRO, 02);
                    break;
                case "Março":
                    dic.Add(MesesAnoEnum.MARCO, 03);
                    break;
                case "Abril":
                    dic.Add(MesesAnoEnum.ABRIL, 04);
                    break;
                case "Maio":
                    dic.Add(MesesAnoEnum.MAIO, 05);
                    break;
                case "Junho":
                    dic.Add(MesesAnoEnum.JULHO, 06);
                    break;
                case "Julho":
                    dic.Add(MesesAnoEnum.JULHO, 07);
                    break;
                case "Setembro":
                    dic.Add(MesesAnoEnum.SETEMBRO, 09);
                    break;
                case "Outubro":
                    dic.Add(MesesAnoEnum.OUTUBRO, 10);
                    break;
                case "Novembro":
                    dic.Add(MesesAnoEnum.NOVEMBRO, 11);
                    break;
                case "Dezembro":
                    dic.Add(MesesAnoEnum.DEZEMBRO, 12);
                    break;
            }

            return dic.First();
        }
    }
}
