using SPG.Util;
using SPG.Util.Enum;
using System;
using System.Globalization;

namespace SPG.Util
{


    public static class DateUtil
    {

        public static string DataAtual(FormatoDataEnum FormatoDeData)
        {

            var formato = FormatoData.ObterFormatoData(FormatoDeData);
            DateTime DataAtual = DateTime.Now;
            return DataAtual.ToString(formato.Value);
        }



        public static DateTime DataAnteriorAoAtual(int quantidadeAnos)
        {

            if (Utilitarios.VerificarObjetoValido(quantidadeAnos))
            {
                var anoAnterior = new DateTime(DateTime.Now.Year - quantidadeAnos, DateTime.Now.Month, DateTime.Now.Day);
                return anoAnterior;
            }
            else
            {
                return new DateTime();
            }

        }

        public static DateTime DataSuperiorAoAtual(int quantidadeAnos)
        {

            if (Utilitarios.VerificarObjetoValido(quantidadeAnos))
            {
                var anoAnterior = new DateTime(DateTime.Now.Year + quantidadeAnos, DateTime.Now.Month, DateTime.Now.Day);
                return anoAnterior;
            }
            else
            {
                return new DateTime();
            }

        }

        public static DateTime ConverterCadeiaCarateresEmDataHora(string Hora, string Data, string Ano)
        {
            try
            {
                
                string objStrData = Data + " " + Ano;
                DateTime ObjDatetime = DateTime.Parse(objStrData);

               var horaTemp = Hora.Substring(0, 2);
               var minutoTemp = Hora.Substring(2, 2);

               var objHoraDouble= Convert.ToInt32(horaTemp);
               var objMinutoDouble=Convert.ToInt32(minutoTemp);

                
                var objDataHora = new DateTime(ObjDatetime.Year, ObjDatetime.Month, ObjDatetime.Day, objHoraDouble, objMinutoDouble, 0);

                return objDataHora;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DateTime AddHourDate(string data,string hour)
        {
            DateTime DataCompleta;
           
            double Hora = 0;
            double Minuto = 0;
           

            try
            {
                var objHoraMinuto = "";
                var horaTemp = "";
                var minutoTemp = "";

                if (hour.Contains(":"))
                {
                    objHoraMinuto = hour.Replace(":", "").Trim();
                    objHoraMinuto = AjustarComprimentoHora(objHoraMinuto);
                   
                    horaTemp = objHoraMinuto.Substring(0, 2);
                    minutoTemp = objHoraMinuto.Substring(2, 2);
                    Hora = Convert.ToDouble(horaTemp);
                    Minuto = Convert.ToDouble(minutoTemp);

                }

                DataCompleta = GetDateTime(data).AddHours(Hora).AddMinutes(Minuto);
                return DataCompleta;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static string AjustarComprimentoHora(string hour)
        {
            if (hour.Length == 1)
            {
                hour = "000" + hour;
            }
            else if (hour.Length == 2)
            {
                hour = "00" + hour;
            }
            else if (hour.Length == 3)
            {
                hour = "0" + hour;
            }
            

            return hour;
        }

        public static DateTime GetDateTime(string data)
        {
            try
            {

                DateTime Data = DateTime.Parse(data);
                return Data;

            }catch(Exception ex)
            {
              
                throw new Exception(ex.Message);
            }
        }


        public static int CompareDate(DateTime dataUm , DateTime dataDois)
        {
            return TimeSpan.Compare(dataUm.TimeOfDay, dataDois.TimeOfDay);
        }



        


        public static string DiaSuperiorAoAtual(int quantidadeDias, FormatoDataEnum FormatoDeData)
        {

            if (Utilitarios.VerificarObjetoValido(quantidadeDias))
            {
                var diaMaiorQueOAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string DiaSuperiorAoAtual = FormatarData(FormatoDeData, diaMaiorQueOAtual.AddDays(quantidadeDias));
                return DiaSuperiorAoAtual;
            }
            else
            {
                return FormatarData(FormatoDeData, new DateTime());
            }

        }



        public static String FormatarData(FormatoDataEnum FormatoDeData, DateTime data)
        {

            if (Utilitarios.VerificarObjetoValido(FormatoDeData))
            {
                var formato = FormatoData.ObterFormatoData(FormatoDeData);
                var anoAnterior = new DateTime(data.Year, data.Month, data.Day);
                return anoAnterior.ToString(formato.Value);
            }

            return "";
        }

        public static string FormatarData(FormatoDataEnum FormatoDeData, DateTime? Data)
        {
            var novaData = Data.Value;
            if (Utilitarios.VerificarObjetoValido(FormatoDeData))
            {
                var formato = FormatoData.ObterFormatoData(FormatoDeData);
                var anoAnterior = new DateTime(novaData.Year, novaData.Month, novaData.Day);
                return anoAnterior.ToString(formato.Value);
            }

            return "";
        }

        public static long DateToLong(DateTime dataAFormatar)
        {
            return (long)dataAFormatar.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        public static string ConvertLongToStringDatetime(long milliseconds, FormatoDataEnum FormatoDeData)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(milliseconds).ToLocalTime();
            var dateString = FormatarData(FormatoDeData, date);
            return Utilitarios.VerificarStringValida(dateString) ? dateString : "";
        }
    }
}