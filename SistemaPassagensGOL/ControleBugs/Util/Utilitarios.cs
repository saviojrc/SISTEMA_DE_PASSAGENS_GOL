using SPG.TO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SPG.Util
{
    public static class Utilitarios
    {
        public static bool VerificarStringValida(string ObjString)
        {
            return VerificarObjetoValido(ObjString) && ObjString.Length > 0;
        }



        public static string SubstituirRegex(string ObjStrAtual)
        {
            ObjStrAtual = VerificarStringValida(ObjStrAtual) ? Regex.Replace(ObjStrAtual, @"\r\n?|\n", "").Trim() : "";
            return ObjStrAtual;
        }
        public static string FormatarMoeda(decimal valor)
        {
            decimal moedaString = VerificarObjetoValido(valor) ? valor : (decimal)0.00;
            var moedaStringFormatada = GetMoedaStringFormatada(moedaString);
            return moedaStringFormatada.Trim();


        }

       

        public static double CalcularValorTotalPassagensMenorTarifa(int quantidadePassageiros, TabelaResumoViagemTO MenorTarifaOrigem, TabelaResumoViagemTO MenorTarifaDestino)
        {
            var objDoubleVrTotal = (MenorTarifaOrigem.ValoresTarifasTO.ValorTarifaPromo>0 ? MenorTarifaOrigem.ValoresTarifasTO.ValorTarifaPromo : MenorTarifaOrigem.ValoresTarifasTO.ValorTarifaLight) + (MenorTarifaDestino.ValoresTarifasTO.ValorTarifaPromo > 0 ? MenorTarifaDestino.ValoresTarifasTO.ValorTarifaPromo : MenorTarifaDestino.ValoresTarifasTO.ValorTarifaLight);
            return Math.Round(objDoubleVrTotal,2) * quantidadePassageiros;
        }

        private static string GetMoedaStringFormatada(decimal moedaString)
        {
            return moedaString.ToString("###,###,##0.00");
        }

        public static string FormatarMoeda(String valor)
        {
            valor = SubstituirRegex(valor);
            valor = valor.Contains("R$") ? valor.Replace("R$", "") : valor;
            var valorDecimal = VerificarStringValida(valor) ? Convert.ToDecimal(valor) : (decimal)0.00;
            var moeda = GetMoedaStringFormatada(valorDecimal);
            return moeda.Trim();


        }



        public static bool VerificarObjetoValido(Object obj)
        {
            return obj != null;

        }





        public static bool EqualsIgnoreCase(string StrAtual, string StrComparation)
        {
            StrAtual = VerificarStringValida(StrAtual) ? StrAtual.Trim() : "";
            StrComparation = VerificarStringValida(StrComparation) ? StrComparation.Trim() : "";
            var comparation = VerificarObjetoValido(StrAtual.Trim().Equals(StrComparation, StringComparison.OrdinalIgnoreCase)) ? StrAtual.Trim().Equals(StrComparation, StringComparison.OrdinalIgnoreCase) : false;
            return comparation;
        }

    }
}
