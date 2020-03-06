
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using System.Linq;
using SPG.Util;
using SPG.Helpers.Util;
using OpenQA.Selenium.Chrome;

namespace Framework.Helpers
{
    public class TelaHelper
    {
        public static IWebDriver Driver { get; set; } = new ChromeDriver();

        public static IJavaScriptExecutor JS = ((IJavaScriptExecutor)Driver);

        public string GetCell(TipoElementoEnum TipoElemento, string strValue, int row, int col)
        {

            IWebElement tabela = GetIWebElement(TipoElemento, strValue);

            List<IWebElement> tr = tabela.FindElements(By.CssSelector("tr")).ToList();
            List<IWebElement> td = tabela.FindElements(By.CssSelector("td")).ToList();

            int rows = tr.Count;
            int cols = td.Count;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (x == row && y == col)
                    {

                        var str = td[y].Text.Trim();
                        return str;
                    }
                }
            }
            return "";

        }


        public int GetRowCount(TipoElementoEnum TipoElemento, string StrValue)
        {

            IWebElement tabela = GetIWebElement(TipoElemento, StrValue);

            List<IWebElement> tr = tabela.FindElements(By.CssSelector("tr")).ToList();
            return Utilitarios.VerificarObjetoValido(tr.Count) ? tr.Count : 0;
        }


        public int GetColumnCount(TipoElementoEnum TipoElemento, string strValue)
        {

            IWebElement tabela = GetIWebElement(TipoElemento, strValue);

            List<IWebElement> td = tabela.FindElements(By.CssSelector("td")).ToList();
            return Utilitarios.VerificarObjetoValido(td.Count) ? td.Count : 0;
        }

        public void SetCell(TipoElementoEnum TipoElemento, String strValue, int row, int col, String value)
        {

            IWebElement tabela = GetIWebElement(TipoElemento, strValue);

            List<IWebElement> tr = tabela.FindElements(By.CssSelector("tr")).ToList();
            List<IWebElement> td = tabela.FindElements(By.CssSelector("td")).ToList();

            int rows = tr.Count;
            int cols = td.Count;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (x == row && y == col)
                    {
                        td[y].SendKeys(value);


                    }
                }
            }


        }



        public bool VerifyCheckBox(TipoElementoEnum TipoElemento, string strValue)
        {

            bool isSelect = Utilitarios.VerificarObjetoValido(GetIWebElement(TipoElemento, strValue).Selected) ? GetIWebElement(TipoElemento, strValue).Selected : false;
            return isSelect;
        }

        public bool VerifyRadioBox(TipoElementoEnum TipoElemento, String strValue)
        {

            bool isSelect = GetPropertyObject(TipoElemento, strValue, "checked").Equals("checked");
            return Utilitarios.VerificarObjetoValido(isSelect) ? isSelect : false;
        }


        public void ClickObject(TipoElementoEnum TipoElemento, String strValue)
        {
            var elemento = GetIWebElement(TipoElemento, strValue);
            WaintPresenceOfAllElementsLocatedForObject(TipoElemento, strValue);
            WaintElementToBeClickable(TipoElemento, strValue);
            elemento.Click();
        }

        public void SetText(TipoElementoEnum TipoElemento, String strValue, String strValueText)
        {
            var elemento = GetIWebElement(TipoElemento, strValue);
            elemento.SendKeys(strValueText.Trim());
        }

        public Boolean IsPropertyObjectIguaisVerify(TipoElementoEnum TipoElemento, String strValue, String strProperty,
            String strPropertyVerify)
        {
            if (Utilitarios.VerificarStringValida(GetPropertyObject(TipoElemento, strValue, strProperty)))
            {
                return GetPropertyObject(TipoElemento, strValue.Trim(), strProperty.Trim()).Equals(strPropertyVerify.Trim());
            }
            else
            {
                return false;
            }
        }

        public void ClickDropDown(TipoElementoEnum TipoElemento, String strValue, String conteudo)
        {
            var elemento = GetIWebElement(TipoElemento, strValue);

            SelectElement dropDrowSelect = new SelectElement(elemento);
            dropDrowSelect.SelectByText(conteudo.Trim());
        }

        public void ClickDropDownIndex(TipoElementoEnum TipoElemento, String strValue, int index)
        {
            var elemento = GetIWebElement(TipoElemento, strValue);

            SelectElement dropDrowSelect = new SelectElement(elemento);
            dropDrowSelect.SelectByIndex(index);
        }


        public void HoverLink(TipoElementoEnum TipoElemento, String strValue)
        {
            var elemento = GetIWebElement(TipoElemento, strValue);
            Actions builder = new Actions(Driver);
            builder.MoveToElement(elemento).Build().Perform();
        }


        public void ClickCheckBox(TipoElementoEnum TipoElemento, String strValue, Boolean isCheck)
        {

            WaintElementToBeClickable(TipoElemento, strValue);
            var elemento = GetIWebElement(TipoElemento, strValue);
            var isElementIsCheck = elemento.Selected;
            if (!isCheck && isElementIsCheck)
            {
                elemento.Click();
            }
            else if (isCheck && !isElementIsCheck)
            {
                elemento.Click();
            }
        }


        public void ClickDropDownValue(TipoElementoEnum TipoElemento, String strValue, String strPropertyValue)
        {
            WaintElementToBeClickable(TipoElemento, strValue);
            var elemento = GetIWebElement(TipoElemento, strValue);

            SelectElement dropDrowSelect = new SelectElement(elemento);
            dropDrowSelect.SelectByValue(strPropertyValue.Trim());
        }


        public String GetPropertyObject(TipoElementoEnum TipoElemento, String strValue, String strProperty)
        {
            var htmlElemnet = GetIWebElement(TipoElemento, strValue);

            var getProperty = htmlElemnet.GetProperty(strProperty);
            return Utilitarios.VerificarStringValida(getProperty) ? getProperty.Trim() : "";
        }

        public string GetAttributeObject(TipoElementoEnum TipoElemento, String strValue, String strProperty)
        {
            var htmlElemnet = GetIWebElement(TipoElemento, strValue);
            
            return Utilitarios.VerificarStringValida(htmlElemnet.GetAttribute(strProperty).Trim()) ? htmlElemnet.GetAttribute(strProperty).Trim() : "";
        }

        public string GetTextSelectComboBox(TipoElementoEnum TipoElemento, string strValue)
        {
            var htmlElemnet = GetIWebElement(TipoElemento, strValue);
            SelectElement SelectElement = new SelectElement(htmlElemnet);
            string wantedText = SelectElement.SelectedOption.Text;

            return wantedText.Trim();
        }

        public void ClearText(TipoElementoEnum TipoElemento, String strValue)
        {
            var elemento = GetIWebElement(TipoElemento, strValue);
            elemento.Clear();
        }


        public void WaintForObject(TipoElementoEnum TipoElemento, String strValue, long timeout)
        {

            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeout));
            var htmlElement = TipoWebElemento.ObterTipoElemento(TipoElemento, strValue);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(htmlElement));




        }




        public void WaintPresenceOfAllElementsLocatedForObject(TipoElementoEnum TipoElemento, String strValue)
        {
        

            var htmlElement = TipoWebElemento.ObterTipoElemento(TipoElemento, strValue);

            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(Parametros.TIME_OUT));

            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(htmlElement));
        }

        public void WaitAtElementsStayVisible(TipoElementoEnum TipoElemento, string strValue)
        {
           


            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(Parametros.TIME_OUT));
            var htmlElement = TipoWebElemento.ObterTipoElemento(TipoElemento, strValue);
            wait.Until(ExpectedConditions.ElementIsVisible(htmlElement));


        }

        public void WaintElementToBeClickable(TipoElementoEnum TipoElemento, String strValue)
        {
           
            var htmlElement = TipoWebElemento.ObterTipoElemento(TipoElemento, strValue);
            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(Parametros.TIME_OUT));
            wait.Until(ExpectedConditions.ElementToBeClickable(htmlElement));
        }
       

        public static void VerificationPointConditional(bool condicaoEsperada, bool condicaoAtual)
        {
            

            condicaoEsperada = Utilitarios.VerificarObjetoValido(condicaoEsperada) ? condicaoEsperada : false;
            condicaoAtual = Utilitarios.VerificarObjetoValido(condicaoAtual) ? condicaoEsperada : false;

            Assert.AreEqual(condicaoEsperada, condicaoAtual);
        }

        public static void VerificationPointConditionalDecimal(decimal condicaoEsperada, decimal condicaoAtual)
        {
           

            condicaoEsperada = Utilitarios.VerificarObjetoValido(condicaoEsperada) ? condicaoEsperada : (decimal)0.00;
            condicaoAtual = Utilitarios.VerificarObjetoValido(condicaoAtual) ? condicaoEsperada : (decimal)0.00;

            Assert.AreEqual(condicaoEsperada, condicaoAtual);
        }

        public static void VerificationPointConditionalString(String condicaoEsperada, String condicaoAtual)
        {

            condicaoEsperada = Utilitarios.VerificarStringValida(condicaoEsperada) ? condicaoEsperada.Trim() : "";
            condicaoAtual = Utilitarios.VerificarStringValida(condicaoAtual) ? condicaoAtual.Trim() : "";
          
            var condicao = Utilitarios.EqualsIgnoreCase(condicaoEsperada, condicaoAtual);
            Assert.AreEqual(true, condicao);
        }

        public static void VerificationPointConditionalDouble(Double condicaoEsperada, Double condicaoAtual)
        {

            
           
           
            Assert.AreEqual(condicaoEsperada, condicaoAtual);
        }

        public static void Sleep(int time)
        {
            Thread.Sleep(time * 1000);
        }

        public IWebElement GetIWebElement(TipoElementoEnum TipoElemento, String strValue)
        {
           

            var htmlElement = TipoWebElemento.ObterTipoElemento(TipoElemento, strValue);

            return Utilitarios.VerificarObjetoValido(Driver.FindElement(htmlElement)) ? Driver.FindElement(htmlElement) : null;

        }



        public static void PrintToConsole(String strCmd)
        {
            Console.WriteLine(strCmd);
        }

        public static void LoadURL(String url)
        {

            Driver.Navigate().GoToUrl(url);
        }

        public static void MaximizeBrowser()
        {
            Driver.Manage().Window.Maximize();
        }


        public static void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
            Driver = null;

        }


        // Trigger down key
        public void TriggerDownKey()
        {
           
        }


        public void TriggerEnterKey()
        {
           
        }

        public void TriggerUpKey()
        {
           
        }


        public void TriggerUpKey(int amountTimes)
        {
            for (int i = 0; i < amountTimes; i++)
            {
                TriggerUpKey();
            }
        }

        public void TriggerHomeKey(int amountTimes)
        {
            for (int i = 0; i < amountTimes; i++)
            {
                TriggerHomeKey();
            }
        }

        private static void TriggerHomeKey()
        {
            Driver.SwitchTo().ActiveElement().SendKeys(Keys.Home);
        }

        public void TriggerTabKey()
        {
            Driver.SwitchTo().ActiveElement().SendKeys(Keys.Tab);
        }

        public void PlaceBeforeCenter()
        {
            ExecuteJavaScript("window.scroll(1000,1000);");
        }


        public void TriggerDownKey(int amountTimes)
        {


            for (int i = 0; i < amountTimes; i++)
            {
                TriggerDownKey();
            }
        }

        public void TriggerEndKey(int amountTimes)
        {

            for (int i = 0; i < amountTimes; i++)
            {
                TriggerEndKey();
            }

        }


        public void TriggerEndKey()
        {
            Driver.SwitchTo().ActiveElement().SendKeys(Keys.End);


        }

        public void MoveToElementPage(TipoElementoEnum TipoElemento, String strValue)
        {
            var element = GetIWebElement(TipoElemento, strValue);
            JS.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }


        public void ExecuteJavaScript(string cmd)
        {
            JS.ExecuteScript(cmd);
        }


        public void DisplayPageTop()
        {
            Sleep(1);
            ExecuteJavaScript("window.scrollBy(0, 0);");
        }

        public void CenterPage()
        {
            Sleep(1);
            ExecuteJavaScript("window.scrollBy(500, 500);");
        }

        public void PositionPageBetweenCenterAndTop()
        {
            ExecuteJavaScript("window.scrollBy(300, 300);");
        }

        public void PositionPageBetweenCenterAndFooter()
        {
            ExecuteJavaScript("window.scrollBy(750, 1000);");
            ExecuteJavaScript("window.scrollBy(200, 300);");
        }

        public void PlacePageOnTop()
        {
            Sleep(5);
            ExecuteJavaScript("window.scrollBy(0, 0);");
        }




        public void SetValueJSBySelector(string Selector,string value)
        {
            string comando = "document.querySelector('"+ Selector.Trim() + "').value=" + "'" + value.Trim() + "';";
            WaitAtElementsStayVisible(TipoElementoEnum.CssSelector, Selector.Trim());
            ExecuteJavaScript(comando);

        }



        
        public void CheckFieldEnabled(TipoElementoEnum TipoElemento, string StrValue, bool IsDisabled)
        {
            var isDisabledScreen = false;
            if (IsDisabled)
            {
                isDisabledScreen = IsPropertyObjectIguaisVerify(TipoElemento, StrValue, "disabled", "disabled");
            }
            else if (!IsDisabled)
            {
                isDisabledScreen = !IsPropertyObjectIguaisVerify(TipoElemento, StrValue, "disabled", "disabled");
            }


            VerificationPointConditional(IsDisabled, isDisabledScreen);


        }
    }






}