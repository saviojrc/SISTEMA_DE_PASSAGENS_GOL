using Framework.Helpers;
using OpenQA.Selenium;
using SPG.DAO;
using SPG.Entidades;
using SPG.Helpers.Util;
using SPG.Helpers.Util.EnumClass;
using SPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SPG.Helpers.PajeObjects
{
    public class DetalheCompraPassagensHelper : TelaHelper
    {
      

        public void selecionarOpcaoFiltroPrecoOrigem()
        {
            var filtro = FiltroVooOrigem.ObterCamposFiltroPassagens(FiltroVooOrigemEnum.FILTRO);
            WaitAtElementsStayVisible(filtro.Key, filtro.Value);
            MoveToElementPage(filtro.Key, filtro.Value);
            ClickObject(filtro.Key, filtro.Value);

        }


        public void selecionarOpcaoFiltroPrecoDestino()
        {
            var filtro = FiltroVooDestino.ObterCamposFiltroPassagens(FiltroVooDestinoEnum.FILTRO);
            WaitAtElementsStayVisible(filtro.Key, filtro.Value);
            MoveToElementPage(filtro.Key, filtro.Value);
            ClickObject(filtro.Key, filtro.Value);

        }


        public void selecionarOpcaoFiltrarPrecoOrigem()
        {
            var filtro = FiltroVooOrigem.ObterCamposFiltroPassagens(FiltroVooOrigemEnum.FILTRAR);
            WaitAtElementsStayVisible(filtro.Key, filtro.Value);
            MoveToElementPage(filtro.Key, filtro.Value);
            ClickObject(filtro.Key, filtro.Value);

        }


        public void selecionarOpcaoFiltrarPrecoDestino()
        {
            var filtro = FiltroVooDestino.ObterCamposFiltroPassagens(FiltroVooDestinoEnum.FILTRAR);
            WaitAtElementsStayVisible(filtro.Key, filtro.Value);
            MoveToElementPage(filtro.Key, filtro.Value);
            ClickObject(filtro.Key, filtro.Value);

        }

        public void SelecionarPrecoAteOrigem(int indice)
        {
            var filtro = FiltroVooOrigem.ObterCamposFiltroPassagens(FiltroVooOrigemEnum.PRECOS_ATE);
            MoveToElementPage(filtro.Key, filtro.Value);



            WaintPresenceOfAllElementsLocatedForObject(filtro.Key, filtro.Value);
            ClickDropDownIndex(filtro.Key, filtro.Value, indice);

        }


        public void SelecionarPrecoAteDestino(int indice)
        {
            var filtro = FiltroVooDestino.ObterCamposFiltroPassagens(FiltroVooDestinoEnum.PRECOS_ATE);

            MoveToElementPage(filtro.Key, filtro.Value);
            WaitAtElementsStayVisible(filtro.Key, filtro.Value);

            var objElement = GetIWebElement(filtro.Key, filtro.Value);


            List<IWebElement> opcoes = objElement.FindElements(By.TagName("option")).ToList();
            if (opcoes.Count <= indice)
            {
                ClickDropDownIndex(filtro.Key, filtro.Value, indice);
            }

        }

        public int ObterQuantidadeResultados(QuantidadeResultadosHorariosViagemEnum QuantidadeResultadosHorarios)
        {
            var objQtd = QuantidadeResultadosHorariosViagem.ObterCamposFiltroPassagens(QuantidadeResultadosHorarios);
            var quantidade = Convert.ToInt32(GetPropertyObject(objQtd.Key, objQtd.Value, "innerText").Trim());

            return quantidade;
        }


       

        public void OrganizarPreco(TipoOrdenacaoPrecoEnum TipoOrdenacao, OrdenacaoPassagensEnum OrdenacaoPassagem)
        {
            var tipoOrdenacaoPreco = TipoOrdenacaoPreco.ObterCamposFiltroPassagens(TipoOrdenacao);
            var ordenacaoPreco = OrdenacaoPassagens.ObterCamposFiltroPassagens(OrdenacaoPassagem);

            WaitAtElementsStayVisible(tipoOrdenacaoPreco.Key, tipoOrdenacaoPreco.Value);
            MoveToElementPage(tipoOrdenacaoPreco.Key, tipoOrdenacaoPreco.Value);
            ClickDropDown(tipoOrdenacaoPreco.Key, tipoOrdenacaoPreco.Value, ordenacaoPreco.Value);
        }

        public  List<InformacoesViagem> ObterListaDoResumoDaViagem(HorariosViagemEnum Horario, int QuantidadeLinhas)
        {
            try {
                
                var valorInicial = 5;
                var listaInformacoesViagem = new List<InformacoesViagem>();

                for (int i=0;i< QuantidadeLinhas;i++)
                {
                    if (i>0)
                    {
                        valorInicial++;
                    }

                    var objCampoHorarioIda = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.DATA_IDA, valorInicial);
                    var objCampoOrigem = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.ORIGEM, valorInicial);
                    var objCampoDuracao = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.DURACAO, valorInicial);
                    var objCampoHoraVolta= TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.DATA_VOLTA, valorInicial);
                    var objCampoDestino = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.DESTINO, valorInicial);
                    var objCampoTarifaMax = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.VALOR_TARIFA_MAX, valorInicial);
                    var objCampoTarifaPlus = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.VALOR_TARIFA_PLUS, valorInicial);
                    var objCampoTarifaLight = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.VALOR_TARIFA_DOUBLE, valorInicial);
                    var objCampoTarifaPromocional = TabelaInformacoesViagem.ObterHtmlInformacoesViagem(Horario, TabelaInformacoesViagemEnum.VALOR_TAFIFA_PROMO, valorInicial);

                    WaitAtElementsStayVisible(TipoElementoEnum.CssSelector, "table.tableTarifasSelect.infoToRemarketing");

                    WaintPresenceOfAllElementsLocatedForObject(objCampoHorarioIda.Key, objCampoHorarioIda.Value);
                    var strCampoHorarioIda = Regex.Replace(GetPropertyObject(objCampoHorarioIda.Key, objCampoHorarioIda.Value, "innerText"), @"\r\n?|\n", "").Replace("Partida","");
                    WaintPresenceOfAllElementsLocatedForObject(objCampoOrigem.Key, objCampoOrigem.Value);
                    var strCampoOrigem = GetPropertyObject(objCampoOrigem.Key, objCampoOrigem.Value, "innerText");
                    WaintPresenceOfAllElementsLocatedForObject(objCampoDuracao.Key, objCampoDuracao.Value);
                    var strCampoDuracao = Utilitarios.SubstituirRegex(GetPropertyObject(objCampoDuracao.Key, objCampoDuracao.Value, "innerText")).Trim().Replace("Duração: ", "").Trim().Replace("Voo Direto", "").Replace("                                 0","");
                    WaintPresenceOfAllElementsLocatedForObject(objCampoHoraVolta.Key, objCampoHoraVolta.Value);
                    var strCampoHoraVolta = Regex.Replace(GetPropertyObject(objCampoHoraVolta.Key, objCampoHoraVolta.Value, "innerText"), @"\r\n?|\n", "").Replace("Chegada", "");
                    WaintPresenceOfAllElementsLocatedForObject(objCampoDestino.Key, objCampoDestino.Value);
                    var strCampoDestino = GetPropertyObject(objCampoDestino.Key, objCampoDestino.Value, "innerText");
                    WaintPresenceOfAllElementsLocatedForObject(objCampoTarifaMax.Key, objCampoTarifaMax.Value);
                    var strCampoTarifaMax = Utilitarios.SubstituirRegex(GetPropertyObject(objCampoTarifaMax.Key, objCampoTarifaMax.Value, "innerText")).Replace("tarifa  Max","").Replace("R$","").Trim();
                    WaintPresenceOfAllElementsLocatedForObject(objCampoTarifaPlus.Key, objCampoTarifaPlus.Value);
                    var strCampoTarifaPlus = Utilitarios.SubstituirRegex(GetPropertyObject(objCampoTarifaPlus.Key, objCampoTarifaPlus.Value, "innerText")).Replace("tarifa  Plus", "").Replace("R$", "").Trim();
                    WaintPresenceOfAllElementsLocatedForObject(objCampoTarifaLight.Key, objCampoTarifaLight.Value);
                    var strCampoTarifaLight = Utilitarios.SubstituirRegex(GetPropertyObject(objCampoTarifaLight.Key, objCampoTarifaLight.Value, "innerText")).Replace("MENOR  PREÇO DO DIA","").Replace("tarifa  Light", "").Replace("R$", "").Trim(); ;
                    var strCampoTarifaPromo = "0,00";

                    if (Horario.Equals(HorariosViagemEnum.DESEMBARQUE))
                    {
                       
                        if (!GetPropertyObject(objCampoTarifaPromocional.Key, objCampoTarifaPromocional.Value, "innerText").Contains("Indisponível"))
                        {
                            WaintPresenceOfAllElementsLocatedForObject(objCampoTarifaPromocional.Key, objCampoTarifaPromocional.Value);
                            WaitAtElementsStayVisible(objCampoTarifaPromocional.Key, objCampoTarifaPromocional.Value);
                            strCampoTarifaPromo = Utilitarios.SubstituirRegex(GetPropertyObject(objCampoTarifaPromocional.Key, objCampoTarifaPromocional.Value, "innerText")).Replace("MENOR  PREÇO DO DIA", "").Replace("tarifa  Promo", "").Replace("R$", "").Trim();
                        }
                    }

                    var informacaoViagem = new InformacoesViagem
                    {
                        Indice = i,
                        HorarioIda = strCampoHorarioIda,
                        Origem= strCampoOrigem,
                        Duracao= strCampoDuracao,
                        HorarioVolta= strCampoHoraVolta,
                        Destino= strCampoDestino,
                        ValorTarifaMax= strCampoTarifaMax,
                        ValorTarifaPlus= strCampoTarifaPlus,
                        ValorTarifaDouble= strCampoTarifaLight,
                        ValorTarifaPromo = strCampoTarifaPromo
                    };

                    listaInformacoesViagem.Add(informacaoViagem);

                   

                }

                return listaInformacoesViagem;


            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }



        public PainelResumoPassagensHelper PainelResumoPassagens()
        {
            return new PainelResumoPassagensHelper();
        }

        public void ExibirOcultarResumoBilhete(bool exibir)
        {

            Sleep(2);
            var objHtml = GetIWebElement(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > a");
            var comando = "document.querySelector('#fareComboBanner > div.fare-combo').style.display =";
            if (exibir == true && !objHtml.Displayed)
            {
               
                MoveToElementPage(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > a");
                comando += "'block';";
                ExecuteJavaScript(comando);
            }
            else if (exibir == false && objHtml.Displayed)
            {
                MoveToElementPage(TipoElementoEnum.CssSelector, "#fareComboBanner > div.fare-combo > a");
                comando += "'none';";
                ExecuteJavaScript(comando);

            }
        }
    }
}
