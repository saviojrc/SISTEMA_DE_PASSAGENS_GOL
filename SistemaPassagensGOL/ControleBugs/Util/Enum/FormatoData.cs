using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Util.Enum
{

    public enum FormatoDataEnum
    {
        DD_MM_YYYYY,
        DD_MM_YYYYY_HH_MM_SS,
        YYYY_MM_DD,
        YYYY,
        DD,
        MM
    }

    public class FormatoData
    {
        public static KeyValuePair<string, string> ObterFormatoData(FormatoDataEnum FormatoData)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();


            switch (FormatoData)
            {
                case FormatoDataEnum.DD_MM_YYYYY:
                    dic.Add("DD_MM_YYYYY", "dd/MM/yyyy");
                    break;
                case FormatoDataEnum.DD_MM_YYYYY_HH_MM_SS:
                    dic.Add("DD_MM_YYYYY_HH_MM_SS", "dd/MM/yyyy hh:mm:ss");
                    break;
                case FormatoDataEnum.YYYY_MM_DD:
                    dic.Add("YYYY_MM_DD", "yyyy/MM/dd");
                    break;
                case FormatoDataEnum.YYYY:
                    dic.Add("YYYY", "yyyy");
                    break;
                case FormatoDataEnum.DD:
                    dic.Add("DD", "dd");
                    break;
                case FormatoDataEnum.MM:
                    dic.Add("MM", "MM");
                    break;
            }
            return dic.First();
        }
    }
}
