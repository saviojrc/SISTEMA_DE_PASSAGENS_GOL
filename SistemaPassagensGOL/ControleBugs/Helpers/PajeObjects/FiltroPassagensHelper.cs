using Framework.Helpers;
using OpenQA.Selenium;
using SPG.Helpers.Util;
using SPG.Helpers.Util.EnumClass;
using SPG.Util;
using SPG.Util.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using static SPG.Helpers.Util.EnumClass.CamposFiltroPassagens;

namespace SPG.Helpers.PajeObjects
{
    public class FiltroPassagensHelper : TelaHelper
    {



        public void FiltrarDestinoOrigem(string origem)
        {

            var campoOrigem = CamposFiltroPassagens.ObterCamposFiltroPassagens(CamposFiltroPassagens.CamposFiltroPassagensEnum.ORIGEM);
            PreencherCampoDeOrigem(origem, campoOrigem);
        }


        public void FiltrarDestinoDestino(string destino)
        {

            var campoDestino = CamposFiltroPassagens.ObterCamposFiltroPassagens(CamposFiltroPassagens.CamposFiltroPassagensEnum.DESTINO);
            PreencherCampoDestino(destino, campoDestino);
        }

        private void PreencherCampoDestino(string destino, KeyValuePair<TipoElementoEnum, string> campoDestino)
        {


            WaintElementToBeClickable(TipoElementoEnum.ClassName, "chosen-placeholder-destiny");
            ClickObject(TipoElementoEnum.ClassName, "chosen-placeholder-destiny");
            WaintPresenceOfAllElementsLocatedForObject(campoDestino.Key, campoDestino.Value);
            SetText(campoDestino.Key, campoDestino.Value, destino);
            selecionarResultadoPesquisaDestino();



        }




        private void PreencherCampoDeOrigem(string origem, KeyValuePair<TipoElementoEnum, string> campoOrigem)
        {
            WaintElementToBeClickable(TipoElementoEnum.ClassName, "chosen-placeholder-origin");
            ClickObject(TipoElementoEnum.ClassName, "chosen-placeholder-origin");
            WaintPresenceOfAllElementsLocatedForObject(campoOrigem.Key, campoOrigem.Value);
            SetText(campoOrigem.Key, campoOrigem.Value, origem);
            selecionarResultadoPesquisaOrigem();

        }

        private void selecionarResultadoPesquisaOrigem()
        {
            WaitAtElementsStayVisible(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-header > div.purchase-box-header-division.division-input.division-input-origin > div.chosen-container.chosen-container-single.chosen-with-drop.chosen-container-active > div > ul > li");
            ClickObject(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-header > div.purchase-box-header-division.division-input.division-input-origin > div.chosen-container.chosen-container-single.chosen-with-drop.chosen-container-active > div > ul > li");
        }

        private void selecionarResultadoPesquisaDestino()
        {
            WaitAtElementsStayVisible(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-header > div.purchase-box-header-division.division-input.division-input-destiny > div.input-destiny.division-input-destiny-city.active > div.chosen-container.chosen-container-single.chosen-with-drop.chosen-container-active > div > ul > li");
            ClickObject(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-header > div.purchase-box-header-division.division-input.division-input-destiny > div.input-destiny.division-input-destiny-city.active > div.chosen-container.chosen-container-single.chosen-with-drop.chosen-container-active > div > ul > li");
        }


        public void PreencherDatasEmbarque(string DataEmbarque)
        {
            PreencherDataEmbarque(DataEmbarque);
        }

        public void PreencherDatasRetorno(string DataRetorno)
        {
            PreencherDataRetorno(DataRetorno);
        }

        public void SelecionarOpcaoBuscarPassagens()
        {
           
            WaitAtElementsStayVisible(TipoElementoEnum.Id, "btn-box-buy");
            ClickObject(TipoElementoEnum.Id, "btn-box-buy");
        }

        private void PreencherDataRetorno(string DataRetorno)
        {
            var dataDestino = "document.querySelector('#datepickerBack').value=" + "'" + DataRetorno.Trim() + "';";
            WaintElementToBeClickable(TipoElementoEnum.Id, "btn-box-buy");
            ExecuteJavaScript(dataDestino);
        }

        private void PreencherDataEmbarque(string DataEmbarque)
        {
            WaintPresenceOfAllElementsLocatedForObject(TipoElementoEnum.Id, "datepickerGo");
            var dataOrigem = "document.querySelector('#datepickerGo').value=" + "'" + DataEmbarque.Trim() + "';";
            WaintPresenceOfAllElementsLocatedForObject(TipoElementoEnum.Id, "datepickerBack");
            ExecuteJavaScript(dataOrigem);
        }


        public void SelecionarOpcaoTrecho(CamposFiltroPassagensEnum OpcaoTrecho, bool marcar)
        {
            var opcao = ObterCamposFiltroPassagens(OpcaoTrecho);

            WaitAtElementsStayVisible(opcao.Key, opcao.Value);

            ClickCheckBox(opcao.Key, opcao.Value, marcar);
        }
        public void InformarQuantidadeAdultos( int Quantidade)
        {
            var opcao = ObterCamposFiltroPassagens(CamposFiltroPassagensEnum.ADULTOS);

            WaintPresenceOfAllElementsLocatedForObject(opcao.Key, opcao.Value);
            WaitAtElementsStayVisible(opcao.Key, opcao.Value);
            ClickObject(opcao.Key, opcao.Value);
            WaintPresenceOfAllElementsLocatedForObject(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-body.purchase-box-body-buy.active > div > div.purchase-box-buy-numbers > div.box-numbers.adults > div.numbers-addRemove > a.numbers-add > span");
            WaitAtElementsStayVisible(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-body.purchase-box-body-buy.active > div > div.purchase-box-buy-numbers > div.box-numbers.adults > div.numbers-addRemove > a.numbers-add > span");
            WaintElementToBeClickable(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-body.purchase-box-body-buy.active > div > div.purchase-box-buy-numbers > div.box-numbers.adults > div.numbers-addRemove > a.numbers-add > span");
            ClickObject(TipoElementoEnum.CssSelector, "#purchase-box > form > div.purchase-box-body.purchase-box-body-buy.active > div > div.purchase-box-buy-numbers > div.box-numbers.adults > div.numbers-addRemove > a.numbers-add > span");
            
        }

    }
}
