using Framework.Helpers;
using SPG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.PajeObjects
{
    public class ComprarPassagensHelper : TelaHelper
    {
        private static string URL = ReadAppConfig.ReadSetting("urlTest");



        public  FiltroPassagensHelper FiltroDePassagens()
        {
            return new FiltroPassagensHelper();
        }


        public DetalheCompraPassagensHelper DetalharPassagens()
        {
            return new DetalheCompraPassagensHelper();
        }


        

        public static void AbrirAplicacao()
        {
            try
            {

                
                LoadURL(URL);
                MaximizeBrowser();
                

            }
            catch (Exception ex)
            {
                CloseBrowser();
               
                throw new Exception(ex.Message);
            }
            
        }


        public static void FecharAplicacao()
        {
            CloseBrowser();

        }
    }
}
