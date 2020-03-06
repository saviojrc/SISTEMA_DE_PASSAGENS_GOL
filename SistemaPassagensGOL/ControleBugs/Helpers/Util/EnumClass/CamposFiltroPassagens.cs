using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{



    public class CamposFiltroPassagens
    {


        public enum CamposFiltroPassagensEnum
        {

            DESTINO,
            ORIGEM,
            IDA_VOLTA,
            SO_IDA_SO_VOLTA,
            VARIOS_TRECHOS,
            STOPOVER,
            DATA_IDA,
            DATA_VOLTA,
            ADULTOS,
            COMPRE_AQUI
        }


        public static KeyValuePair<TipoElementoEnum, string> ObterCamposFiltroPassagens(CamposFiltroPassagensEnum CamposFiltroPassagens)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (CamposFiltroPassagens)
            {
                case CamposFiltroPassagensEnum.DESTINO:
                    dic.Add(TipoElementoEnum.Id, "header-chosen-destiny");
                    break;
                case CamposFiltroPassagensEnum.ORIGEM:
                    dic.Add(TipoElementoEnum.Id, "header-chosen-origin");
                    break;
                case CamposFiltroPassagensEnum.IDA_VOLTA:
                    dic.Add(TipoElementoEnum.Id, "goAndBack");
                    break;
                case CamposFiltroPassagensEnum.SO_IDA_SO_VOLTA:
                    dic.Add(TipoElementoEnum.Id, "goOrBack");
                    break;
                case CamposFiltroPassagensEnum.VARIOS_TRECHOS:
                    dic.Add(TipoElementoEnum.Id, "goOrBack");
                    break;
                case CamposFiltroPassagensEnum.STOPOVER:
                    dic.Add(TipoElementoEnum.Id, ".stopover-onOff");
                    break;
                case CamposFiltroPassagensEnum.DATA_IDA:
                    dic.Add(TipoElementoEnum.CssSelector, ".chosen-container-active > a:nth-child(1) > span:nth-child(1)");
                    break;
                case CamposFiltroPassagensEnum.DATA_VOLTA:
                    dic.Add(TipoElementoEnum.Id, "datepickerBack");
                    break;
                case CamposFiltroPassagensEnum.ADULTOS:
                    dic.Add(TipoElementoEnum.Id, "number-adults");
                    break;
                case CamposFiltroPassagensEnum.COMPRE_AQUI:
                    dic.Add(TipoElementoEnum.Id, "adtInputPax");
                    break;
            }

            return dic.First();
        }

    }

}
