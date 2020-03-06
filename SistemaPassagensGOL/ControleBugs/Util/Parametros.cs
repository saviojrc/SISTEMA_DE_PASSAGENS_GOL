using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Util
{
    public class Parametros
    {


        public static string URL = ObterParametro("urlTest");
        public static long TIME_OUT = Convert.ToInt64(ObterParametro("timeOut"));

        private static string ObterParametro(string Parametro)
        {
            string valorParametro = ReadAppConfig.ReadSetting(Parametro);

            valorParametro = Utilitarios.VerificarObjetoValido(valorParametro) ? valorParametro : "";

            return Utilitarios.VerificarObjetoValido(valorParametro) ? valorParametro : "";
        }
    }
}
