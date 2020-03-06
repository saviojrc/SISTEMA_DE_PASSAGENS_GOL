using Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Helpers.Util
{
    public class DatepickerHelper : TelaHelper
    {
        public IWebElement Voltar()
        {
            return GetIWebElement(TipoElementoEnum.CssSelector, "a.ui-datepicker-prev");
        }

        public IWebElement Avancar()
        {
            return GetIWebElement(TipoElementoEnum.CssSelector, "a.ui-datepicker-next");
        }

        public IWebElement DataAtual()
        {
            return GetIWebElement(TipoElementoEnum.CssSelector, "div.ui-datepicker-title");
        }


     

    }
}
