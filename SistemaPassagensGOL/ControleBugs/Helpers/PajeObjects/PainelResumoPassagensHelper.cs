using Framework.Helpers;
using SPG.Entidades;
using SPG.Helpers.Util.EnumClass;
using SPG.TO;
using SPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.PajeObjects
{
    public class PainelResumoPassagensHelper : TelaHelper
    {

        public void SelecionarOpcaoComprarPassagens()
        {
            var objPrpPainel = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.PAINEL);
            var objPrpComprar = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.COMPRAR);

            WaintPresenceOfAllElementsLocatedForObject(objPrpPainel.Key, objPrpPainel.Value);
            WaitAtElementsStayVisible(objPrpPainel.Key, objPrpPainel.Value);

            WaintPresenceOfAllElementsLocatedForObject(objPrpPainel.Key, objPrpPainel.Value);
            WaitAtElementsStayVisible(objPrpComprar.Key, objPrpComprar.Value);
            ClickObject(objPrpComprar.Key, objPrpComprar.Value);
        }

        public  PainelResumoPassagens ObterResumoPassagens()
        {
            try
            {

                
                var objPrpPainel = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.PAINEL);

                var objPrpDataIdaEmbarque = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.DATA_IDA);
                var objPrpHoraEmbarqueIda = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.HORARIO_EMBARQUE_IDA);
                var objPrpHoraDesembarqueIda= PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.HORARIO_DESEMBARQUE_IDA);


               
                var objPrpDataEmbarqueVolta = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.DATA_VOLTA);
                var objPrpHoraEmbarqueVolta = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.HORARIO_EMBARQUE_VOLTA);
                var objPrpHoraDesembarqueVolta = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.HORARIO_DESEMBARQUE_VOLTA);

                var objPrpQuantidadePassageiros = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.QUANTIDADE_PASSAGEIROS);
                var objPrpValorPassagens = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.VALOR_PASSAGENS);
                var objPrpValorTxEmbarque = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.VALOR_TAXA_EMBARQUE);
                var objPrpValorTotal = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.VALOR_TOTAL_PASSAGENS);
                 
                var objPrpBtnComprar = PainelResumoPassagem.ObterPainelResumoPassagem(PainelResumoPassagemEnum.COMPRAR);

                WaintPresenceOfAllElementsLocatedForObject(objPrpPainel.Key, objPrpPainel.Value);
                WaitAtElementsStayVisible(objPrpPainel.Key, objPrpPainel.Value);

                //innerText
                var objStrpDataIdaEmbarque = GetPropertyObject(objPrpDataIdaEmbarque.Key, objPrpDataIdaEmbarque.Value, "innerText").Trim();
                var objStrHoraEmbarqueIda = GetPropertyObject(objPrpHoraEmbarqueIda.Key, objPrpHoraEmbarqueIda.Value, "innerText").Trim().Replace("h","");
                var objStrHoraDesembarqueIda = GetPropertyObject(objPrpHoraDesembarqueIda.Key, objPrpHoraDesembarqueIda.Value, "innerText").Trim().Replace("h", "");



                var objStrDataEmbarqueVolta = GetPropertyObject(objPrpDataEmbarqueVolta.Key, objPrpDataEmbarqueVolta.Value, "innerText").Trim();
                var objStrHoraEmbarqueVolta = GetPropertyObject(objPrpHoraEmbarqueVolta.Key, objPrpHoraEmbarqueVolta.Value, "innerText").Trim().Replace("h", "");
                var objStrHoraDesembarqueVolta = GetPropertyObject(objPrpHoraDesembarqueVolta.Key, objPrpHoraDesembarqueVolta.Value, "innerText").Trim().Replace("h", "");

                var objStrQuantidadePassageiros = GetPropertyObject(objPrpQuantidadePassageiros.Key, objPrpQuantidadePassageiros.Value, "innerText").Replace("adulto(s)","").Trim();
                var objStrValorPassagens = Utilitarios.FormatarMoeda(GetPropertyObject(objPrpValorPassagens.Key, objPrpValorPassagens.Value, "innerText").Trim());
                var objStrValorTxEmbarque = Utilitarios.FormatarMoeda(GetPropertyObject(objPrpValorTxEmbarque.Key, objPrpValorTxEmbarque.Value, "innerText").Trim());
                var objStrValorTotal = Utilitarios.FormatarMoeda(GetPropertyObject(objPrpValorTotal.Key, objPrpValorTotal.Value, "innerText").Trim());


                var objPainel = new PainelResumoPassagens
                {
                    DataIda=objStrpDataIdaEmbarque,
                    HorarioEmbarqueIda = objStrHoraEmbarqueIda,
                    HorarioDesembarqueIda=objStrHoraDesembarqueIda,
                    DataVolta = objStrDataEmbarqueVolta,
                    HorarioEmbarqueVolta = objStrHoraEmbarqueVolta,
                    HorarioDesembarqueVolta = objStrHoraDesembarqueVolta,
                    QuantidadePassageiros=objStrQuantidadePassageiros,
                    ValorPassagens=objStrValorPassagens,
                    ValorTaxaEmbarque=objStrValorTxEmbarque,
                    ValorTotalPassagens=objStrValorTotal
                };

                return objPainel;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
 
