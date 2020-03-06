using OpenQA.Selenium;

namespace SPG.Helpers.Util
{


    public enum TipoElementoEnum
    {

        Id,
        ClassName,
        CssSelector,
        LinkText,
        Name,
        PartialLinkText,
        TagName,
        XPath


    }


    public class TipoWebElemento
    {

        public static By ObterTipoElemento(TipoElementoEnum TipoElementoEnum, string StrValue)
        {



            if (TipoElementoEnum.Equals(TipoElementoEnum.Id))
            {
                return By.Id(StrValue);
            }
            else if (TipoElementoEnum.Equals(TipoElementoEnum.ClassName))
            {
                return By.ClassName(StrValue);
            }
            else if (TipoElementoEnum.Equals(TipoElementoEnum.CssSelector))
            {
                return By.CssSelector(StrValue);
            }
            else if (TipoElementoEnum.Equals(TipoElementoEnum.Name))
            {
                return By.Name(StrValue);
            }
            else if (TipoElementoEnum.Equals(TipoElementoEnum.LinkText))
            {
                return By.LinkText(StrValue);
            }
            else if (TipoElementoEnum.Equals(TipoElementoEnum.PartialLinkText))
            {
                return By.PartialLinkText(StrValue);
            }
            else if (TipoElementoEnum.Equals(TipoElementoEnum.TagName))
            {
                return By.TagName(StrValue);
            }
            else
            {
                return By.XPath(StrValue);
            }


        }
    }
}
