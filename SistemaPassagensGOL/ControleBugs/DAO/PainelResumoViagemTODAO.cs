using SPG.Entidades;
using SPG.TO;
using SPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DAO
{
    public class PainelResumoViagemTODAO
    {

        public PainelResumoViagemTO ObterPainelResumoViagemTO(PainelResumoPassagens PainelResumoPassagens,string AnoViagem)
        {
            try
            {
                var dataIdaEmbarque = DateUtil.ConverterCadeiaCarateresEmDataHora(PainelResumoPassagens.HorarioEmbarqueIda, PainelResumoPassagens.DataIda,AnoViagem);
                var dataIdaDesembarque = DateUtil.ConverterCadeiaCarateresEmDataHora(PainelResumoPassagens.HorarioDesembarqueIda, PainelResumoPassagens.DataIda, AnoViagem);
                var dataVoltaEmbarque = DateUtil.ConverterCadeiaCarateresEmDataHora(PainelResumoPassagens.HorarioEmbarqueVolta, PainelResumoPassagens.DataVolta, AnoViagem);
                var dataVoltaDesembarque = DateUtil.ConverterCadeiaCarateresEmDataHora(PainelResumoPassagens.HorarioDesembarqueVolta, PainelResumoPassagens.DataVolta, AnoViagem);
                var quantidadePassageiros = Convert.ToInt32(PainelResumoPassagens.QuantidadePassageiros);
                var valorPassagens = Convert.ToDouble(PainelResumoPassagens.ValorPassagens);
                var valorTaxaEmbaque = Convert.ToDouble(PainelResumoPassagens.ValorTaxaEmbarque);
                var valorTotalPassagens = Convert.ToDouble(PainelResumoPassagens.ValorTotalPassagens);

                var objPainelResumoViagemTO = new PainelResumoViagemTO
                {
                    DataIdaEmbarque= dataIdaEmbarque,
                    DataIdaDesembarque=dataIdaDesembarque,
                    DataVoltaEmbarque=dataVoltaEmbarque,
                    DataVoltaDesembarque = dataVoltaDesembarque,
                    QuantidadePassageiros=quantidadePassageiros,
                    ValorPassagens=valorPassagens,
                    ValorTaxaEmbarque=valorTaxaEmbaque,
                    ValorTotalPassagens = valorTotalPassagens
                };

                return objPainelResumoViagemTO;
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
