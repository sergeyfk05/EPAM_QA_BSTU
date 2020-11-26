using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace WebDriverTests
{
    public static class Helpers
    {
        public static void AcceptCookies(this IWebDriver driver)
        {
            ReadOnlyCollection<IWebElement> cookieUsageAcceptButtons = driver.FindElements(By.XPath("//button[@id='_evidon-accept-button']"));
            if (cookieUsageAcceptButtons.Count > 0)
            {
                cookieUsageAcceptButtons[0].Click();
            }
        }

        public static IWebElement SafeFindElementByXpath(this IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(d => d.FindElement(By.XPath(xpath)));
        }

        public static string GetHiddenText(this IWebElement element, IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].innerText", element).ToString().Trim();
        }

        public static readonly NumberFormatInfo CostToDoubleConverterProvider = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ",",
            NumberGroupSizes = new int[] { 3 }
        };
    }
}
