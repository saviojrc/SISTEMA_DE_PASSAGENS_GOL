using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPG.DAO;
using SPG.Entidades;
using SPG.Helpers.PajeObjects;
using SPG.Helpers.Util;
using SPG.Helpers.Util.EnumClass;
using SPG.TO;
using SPG.Util;
using SPG.Util.Enum;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using static SPG.Helpers.Util.EnumClass.CamposFiltroPassagens;

namespace SPG.Steps
{
    [Binding]
    public class ComprarPassagensPeloMenorPrecoSteps : ComprarPassagensHelper
    {

        private string DataOrigem;
        private string DataDestino;
        private int QuantidadeOrigem;
        private int QuantidadeDestino;
        private TabelaResumoViagemTO MenorTarifaEmbarque = new TabelaResumoViagemTO();
        private TabelaResumoViagemTO MenorTarifaDesembarque = new TabelaResumoViagemTO();
        private TabelaResumoViagemDAO DadosTabelaResumoViagem = new TabelaResumoViagemDAO();
        private List<string> ListaHorarios = new List<string>();
        private PainelResumoPassagens PainelResumoPassagens = new PainelResumoPassagens();
        private PainelResumoViagemTO PainelResumoViagemTO = new PainelResumoViagemTO();
        private PainelResumoViagemTODAO daoPainelResumoViagem = new PainelResumoViagemTODAO();
        private string AnoAtual;
        private double ValorTotalPassagensTabela;
        private double ValorTotalPassagensResumo;
        private int QuantidadePassageiros;
        private string Origem;
        private string Destino;

        [BeforeFeature("ComprarPassagens")]
        public static void AbrirApp()
        {

            AbrirAplicacao();
        }

        [AfterFeature("ComprarPassagens")]
        public static void FecharApp()
        {
            FecharAplicacao();

        }

        [Given(@"um passageiro que deseja realizar a compra de passagens pelo menos preço")]
        public void DadoUmPassageiroQueDesejaRealizarACompraDePassagensPeloMenosPreco()
        {
            AnoAtual = DateUtil.DataAtual(FormatoDataEnum.YYYY);
            DataOrigem = DateUtil.DiaSuperiorAoAtual(1, FormatoDataEnum.DD_MM_YYYYY);
            DataDestino = DateUtil.DiaSuperiorAoAtual(61, FormatoDataEnum.DD_MM_YYYYY);
        }
        
        [When(@"o usuário seleciona o destino igual a ""(.*)"" e o Destino igual a ""(.*)""")]
        public void QuandoOUsuarioSelecionaODestinoIgualAEODestinoIgualA(string p0, string p1)
        {
            Origem = p0;
            Destino = p1;

            FiltroDePassagens().FiltrarDestinoOrigem(p0);
            FiltroDePassagens().FiltrarDestinoDestino(p1);
        }
        
        [When(@"seleciono a opção para comprar as passagens de ida e de volta\.")]
        public void QuandoSelecionoAOpcaoParaComprarAsPassagensDeIdaEDeVolta_()
        {
            FiltroDePassagens().SelecionarOpcaoTrecho(CamposFiltroPassagensEnum.IDA_VOLTA, true);
        }
        
        [When(@"informo a data da ida  um dia superior a data atual")]
        public void QuandoInformoADataDaIdaUmDiaSuperiorADataAtual()
        {
            FiltroDePassagens().PreencherDatasEmbarque(DataOrigem);
        }
        
        [When(@"a data de volta dois meses superior a  data de ida")]
        public void QuandoADataDeVoltaDoisMesesSuperiorADataDeIda()
        {
            FiltroDePassagens().PreencherDatasRetorno(DataDestino);
        }
        
        [When(@"seleciono a quantidade de ""(.*)"" adultos")]
        public void QuandoSelecionoAQuantidadeDeAdultos(int p0)
        {
            QuantidadePassageiros = Convert.ToInt32(p0);
            FiltroDePassagens().InformarQuantidadeAdultos(p0);
        }
        
        [When(@"seleciono a opção ""(.*)""")]
        public void QuandoSelecionoAOpcao(string p0)
        {
            DisplayPageTop();
            FiltroDePassagens().SelecionarOpcaoBuscarPassagens();
        }
        
        [When(@"seleciono a opção para organizar o voo de ida pela tarifa tarifa mais baixa;")]
        public void QuandoSelecionoAOpcaoParaOrganizarOVooDeIdaPelaTarifaTarifaMaisBaixa()
        {
            QuantidadeOrigem = DetalharPassagens().ObterQuantidadeResultados(QuantidadeResultadosHorariosViagemEnum.EMBARQUE);
            QuantidadeDestino = DetalharPassagens().ObterQuantidadeResultados(QuantidadeResultadosHorariosViagemEnum.DESEMBARQUE);
            CenterPage();
            DetalharPassagens().ExibirOcultarResumoBilhete(false);
            DetalharPassagens().OrganizarPreco(TipoOrdenacaoPrecoEnum.ORIGEM, OrdenacaoPassagensEnum.TARIFA_MAIS_BAIXA);
        }
        
        [When(@"seleciono a opção para organizar o voo de volta pela tarifa tarifa mais baixa;")]
        public void QuandoSelecionoAOpcaoParaOrganizarOVooDeVoltaPelaTarifaTarifaMaisBaixa()
        {
            CenterPage();
            DetalharPassagens().ExibirOcultarResumoBilhete(false);
            DetalharPassagens().OrganizarPreco(TipoOrdenacaoPrecoEnum.DESTINO, OrdenacaoPassagensEnum.TARIFA_MAIS_BAIXA);
        }
        
        [When(@"seleciono a opção para filtrar o voo de ida pela tarifa com o menor preço;")]
        public void QuandoSelecionoAOpcaoParaFiltrarOVooDeIdaPelaTarifaComOMenorPreco()
        {
            CenterPage();
            DetalharPassagens().ExibirOcultarResumoBilhete(false);
            DetalharPassagens().selecionarOpcaoFiltroPrecoOrigem();
            DetalharPassagens().SelecionarPrecoAteOrigem(0);
            DetalharPassagens().selecionarOpcaoFiltrarPrecoOrigem();
        }
        
        [When(@"seleciono a opção para filtrar o voo de volta pela tarifa com o menor preço;")]
        public void QuandoSelecionoAOpcaoParaFiltrarOVooDeVoltaPelaTarifaComOMenorPreco()
        {
            DetalharPassagens().selecionarOpcaoFiltroPrecoDestino();
            DetalharPassagens().SelecionarPrecoAteDestino(0);
            DetalharPassagens().selecionarOpcaoFiltrarPrecoDestino();
        }
        
        [When(@"seleciono ""(.*)""")]
        public void QuandoSeleciono(string p0)
        {
            var listaDeTarifasEmbarque = DetalharPassagens().ObterListaDoResumoDaViagem(HorariosViagemEnum.EMBARQUE, QuantidadeOrigem);
            var listaTarifaEmbarque = DadosTabelaResumoViagem.ObterTabelaResumoViagemTO(DataOrigem, DataDestino, DataOrigem, listaDeTarifasEmbarque);
            MenorTarifaEmbarque = DadosTabelaResumoViagem.ObterTarifaMaisBaixaNoHorarioMaisCedo(listaTarifaEmbarque);

            var listaDeTarifasDesembarque = DetalharPassagens().ObterListaDoResumoDaViagem(HorariosViagemEnum.DESEMBARQUE, QuantidadeDestino);
            var listaTarifaEmbarqueDesembarque = DadosTabelaResumoViagem.ObterTabelaResumoViagemTO(DataOrigem, DataDestino, DataDestino, listaDeTarifasDesembarque);
            MenorTarifaDesembarque = DadosTabelaResumoViagem.ObterTarifaMaisBaixaNoHorarioMaisCedo(listaTarifaEmbarqueDesembarque);

            DetalharPassagens().ExibirOcultarResumoBilhete(true);
            PainelResumoPassagens = DetalharPassagens().PainelResumoPassagens().ObterResumoPassagens();
            PainelResumoViagemTO = daoPainelResumoViagem.ObterPainelResumoViagemTO(PainelResumoPassagens, AnoAtual);

            ValorTotalPassagensTabela = Utilitarios.CalcularValorTotalPassagensMenorTarifa(QuantidadePassageiros, MenorTarifaEmbarque, MenorTarifaDesembarque);
            ValorTotalPassagensResumo = Math.Round(PainelResumoViagemTO.ValorTotalPassagens, 2);

            DetalharPassagens().PainelResumoPassagens().SelecionarOpcaoComprarPassagens();
        }
        
        [Then(@"o Sistema exibe o resumo o resumo da compra das passagens de ida e volta com o menor preço e o o primeiro horário de voo")]
        public void EntaoOSistemaExibeOResumoOResumoDaCompraDasPassagensDeIdaEVoltaComOMenorPrecoEOOPrimeiroHorarioDeVoo()
        {
            DetalharPassagens().PositionPageBetweenCenterAndTop();
            WaintPresenceOfAllElementsLocatedForObject(TipoElementoEnum.CssSelector, "#valueNoCentsWithCar");
            WaitAtElementsStayVisible(TipoElementoEnum.CssSelector, "#valueNoCentsWithCar");

            var objStrAreportoOrigemIda = GetPropertyObject(TipoElementoEnum.CssSelector, "#IdaFly > div.idaSCDetail.LightSB.journeyTitle > div > div.trechoida > div.titleT", "innerText").Trim();
            var objStrAreportoDestinoIda = GetPropertyObject(TipoElementoEnum.CssSelector, "#IdaFly > div.idaSCDetail.LightSB.journeyTitle > div > div.trechoVolta > div.titleT", "innerText").Trim();

            var objStrAreportoOrigemVolta = GetPropertyObject(TipoElementoEnum.CssSelector, "#VoltaFly > div.idaSCDetail.PromoSB.journeyTitle > div > div.trechoida > div.titleT", "innerText").Trim();
            var objStrAreportoDestinoVolta = GetPropertyObject(TipoElementoEnum.CssSelector, "#VoltaFly > div.idaSCDetail.PromoSB.journeyTitle > div > div.trechoVolta > div.titleT", "innerText").Trim();

            var objStrDataHoraOrigemIda = GetPropertyObject(TipoElementoEnum.CssSelector, "#IdaFly > div.idaSCDetail.LightSB.journeyTitle > div > div.trechoida > div.subtitleT", "innerText").Replace("h", "").Trim();
            var objStrDataHoraDestinoIda = GetPropertyObject(TipoElementoEnum.CssSelector, "#IdaFly > div.idaSCDetail.LightSB.journeyTitle > div > div.trechoVolta > div.subtitleT", "innerText").Replace("h", "").Trim();

            var objStrDataHoraOrigemVolta = GetPropertyObject(TipoElementoEnum.CssSelector, "#VoltaFly > div.idaSCDetail.PromoSB.journeyTitle > div > div.trechoida > div.subtitleT", "innerText").Replace("h", "").Trim();
            var objStrDataHoraVolta = GetPropertyObject(TipoElementoEnum.CssSelector, "#VoltaFly > div.idaSCDetail.PromoSB.journeyTitle > div > div.trechoVolta > div.subtitleT", "innerText").Replace("h", "").Trim();

            var objStringSubTotal = GetPropertyObject(TipoElementoEnum.CssSelector, "#valueNoCentsWithCar", "innerText").Replace("R$", "").Trim();
            var objStringCentavos = GetPropertyObject(TipoElementoEnum.Id, "valueCentsWithCar", "innerText");

            var objStringValorTotal = objStringSubTotal.Trim() + "," + objStringCentavos.Trim();
            var objStringDoubleTotal = Convert.ToDouble(objStringValorTotal);




            var objStringDataHoraEmbarqueIdaEsperado = PainelResumoPassagens.DataIda + " - " + PainelResumoPassagens.HorarioEmbarqueIda;
            var objStringDataHoraDesembarqueIdaEsperado = PainelResumoPassagens.DataIda + " - " + PainelResumoPassagens.HorarioDesembarqueIda;

            var objStringDataHoraEmbarqueVoltaEsperado = PainelResumoPassagens.DataVolta + " - " + PainelResumoPassagens.HorarioEmbarqueVolta;
            var objStringDataHoraDesembarqueVoltaEsperado = PainelResumoPassagens.DataVolta + " - " + PainelResumoPassagens.HorarioDesembarqueVolta;


            VerificationPointConditionalString(Origem, objStrAreportoOrigemIda);
            VerificationPointConditionalString(Destino, objStrAreportoOrigemVolta);
            VerificationPointConditionalString(Destino, objStrAreportoDestinoIda);
            VerificationPointConditionalString(Origem, objStrAreportoDestinoVolta);

            VerificationPointConditionalString(objStringDataHoraEmbarqueIdaEsperado, objStrDataHoraOrigemIda);
            VerificationPointConditionalString(objStringDataHoraDesembarqueIdaEsperado, objStrDataHoraDestinoIda);
            VerificationPointConditionalString(objStringDataHoraEmbarqueVoltaEsperado, objStrDataHoraOrigemVolta);
            VerificationPointConditionalString(objStringDataHoraDesembarqueVoltaEsperado, objStrDataHoraVolta);

            VerificationPointConditionalDouble(ValorTotalPassagensTabela, ValorTotalPassagensResumo);

            VerificationPointConditionalDouble(ValorTotalPassagensResumo, objStringDoubleTotal);
        }
    }
}
