using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util.EnumClass
{

    public enum TabelaInformacoesViagemEnum
    {
    
        DATA_IDA,
        ORIGEM,
        DURACAO,
        DATA_VOLTA,
        DESTINO,
        VALOR_TARIFA_MAX,
        VALOR_TARIFA_PLUS,
        VALOR_TARIFA_DOUBLE,
        VALOR_TAFIFA_PROMO

    
    }
    
    public class TabelaInformacoesViagem
    {

        public static KeyValuePair<TipoElementoEnum, string> ObterHtmlInformacoesViagem(HorariosViagemEnum TipoHorario, TabelaInformacoesViagemEnum TabelaInformacoesViagem, int linha)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            var htmlCompleto = obterHTMLCompleto(TipoHorario, TabelaInformacoesViagem, linha);

            switch (TipoHorario)
            {
                case HorariosViagemEnum.EMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, htmlCompleto);
                    break;
                case HorariosViagemEnum.DESEMBARQUE:
                    dic.Add(TipoElementoEnum.CssSelector, htmlCompleto);
                    break;


            }

            return dic.First();
        }


        

        private static KeyValuePair<TipoElementoEnum, string> ObterElementoHtmlInformacoesViagem(TabelaInformacoesViagemEnum TabelaInformacoesViagem, int linha)
        {
            Dictionary<TipoElementoEnum, string> dic = new Dictionary<TipoElementoEnum, string>();

            switch (TabelaInformacoesViagem)
            {
                case TabelaInformacoesViagemEnum.DATA_IDA:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.firstColumn > div > div.scale > div.infoScale > span:nth-child(1)");
                    break;
                case TabelaInformacoesViagemEnum.ORIGEM:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.firstColumn > div > div.scale > div.infoScale > span:nth-child(2)");
                    break;
                case TabelaInformacoesViagemEnum.DURACAO:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.firstColumn > div > div.scale > div.infoScale > span:nth-child(3)");
                    break;
                case TabelaInformacoesViagemEnum.DATA_VOLTA:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.firstColumn > div > div.scale > div.infoScale > span:nth-child(4)");
                    break;
                case TabelaInformacoesViagemEnum.DESTINO:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.firstColumn > div > div.scale > div.infoScale > span:nth-child(5)");
                    break;
                case TabelaInformacoesViagemEnum.VALOR_TARIFA_MAX:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.taxa.taxaComfort");
                    break;
                case TabelaInformacoesViagemEnum.VALOR_TARIFA_PLUS:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.taxa.taxaExecutiva");
                    break;
                case TabelaInformacoesViagemEnum.VALOR_TARIFA_DOUBLE:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.taxa.taxaPromocional");
                    break;
                case TabelaInformacoesViagemEnum.VALOR_TAFIFA_PROMO:
                    dic.Add(TipoElementoEnum.CssSelector, " > div.ContentTable > div:nth-child(" + (linha) + ") > table.tableTarifasSelect.infoToRemarketing > tbody > tr > td.taxa.taxaFlexivel");
                    break;

            }

            return dic.First();
        }

        private static string obterHTMLCompleto(HorariosViagemEnum TipoHorario, TabelaInformacoesViagemEnum TabelaInformacoesViagem, int linha)
        {
            var objTipoHorario = HorariosViagem.ObterCamposHorariosViagem(TipoHorario);
            var objInformacoeViagem = ObterElementoHtmlInformacoesViagem(TabelaInformacoesViagem, linha);

            var htmlCompleto = objTipoHorario.Value + objInformacoeViagem.Value;

            return htmlCompleto;
        }

    }
}
