using SPG.Entidades;
using SPG.TO;
using SPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPG.DAO
{
    public class TabelaResumoViagemDAO
    {

        public List<TabelaResumoViagemTO> ObterTabelaResumoViagemTO(string objStrDataIda, string objStrDataRetorno, string objStrDataDuracao, List<InformacoesViagem> ListarInformacoesViagem)
        {
            try
            {
                var listaTarifaria = new List<TabelaResumoViagemTO>();
                for (int i = 0; i < ListarInformacoesViagem.Count; i++)
                {
                    var informacoesTarifa = ListarInformacoesViagem.ElementAt(i);



                    var objTabelaResumoViagem = new TabelaResumoViagemTO
                    {
                        Indice = informacoesTarifa.Indice,
                        HorarioIda = DateUtil.AddHourDate(objStrDataIda, informacoesTarifa.HorarioIda),
                        Origem = informacoesTarifa.Origem,
                        Duracao = DateUtil.AddHourDate(objStrDataDuracao, informacoesTarifa.Duracao),
                        HorarioVolta = DateUtil.AddHourDate(objStrDataRetorno, informacoesTarifa.HorarioVolta),
                        Destino = informacoesTarifa.Destino,
                        ValoresTarifasTO = new ValoresTarifasTO
                        {
                            ValorTarifaMax = Convert.ToDouble(informacoesTarifa.ValorTarifaMax),
                            ValorTarifaPlus = Convert.ToDouble(informacoesTarifa.ValorTarifaPlus),
                            ValorTarifaLight = Convert.ToDouble(informacoesTarifa.ValorTarifaDouble),
                            ValorTarifaPromo= Convert.ToDouble(informacoesTarifa.ValorTarifaPromo)
                        }
                    };
                    listaTarifaria.Add(objTabelaResumoViagem);
                }

                return listaTarifaria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public TabelaResumoViagemTO ObterTarifaMaisBaixaNoHorarioMaisCedo(List<TabelaResumoViagemTO> ListaDeResumoDeViagem )
        {
            var objMenorValorEPreco = new TabelaResumoViagemTO();
            var objListaPromo = new List<TabelaResumoViagemTO>();
            var objListaLight = new List<TabelaResumoViagemTO>();
            for (int i=0;i< ListaDeResumoDeViagem.Count;i++)
            {
                var TabelaResumoViagemTO = ListaDeResumoDeViagem.ElementAt(i);

                if (TabelaResumoViagemTO.ValoresTarifasTO.ValorTarifaPromo>0)
                {
                    objListaPromo.Add(TabelaResumoViagemTO);
                }
                else if (TabelaResumoViagemTO.ValoresTarifasTO.ValorTarifaPromo== 0)
                {
                    objListaLight.Add(TabelaResumoViagemTO);
                }
            }

            if (objListaPromo.Count>0)
            {
                objMenorValorEPreco = objListaPromo.OrderBy(preco => preco.ValoresTarifasTO.ValorTarifaPromo).OrderBy(horario => horario.HorarioIda).FirstOrDefault();
            }else
            {
                objMenorValorEPreco = objListaLight.OrderBy(preco => preco.ValoresTarifasTO.ValorTarifaLight).OrderBy(horario => horario.HorarioIda).FirstOrDefault();
            }

            return objMenorValorEPreco;
        }



    }
}
