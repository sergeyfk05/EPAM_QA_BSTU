using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace DellPages
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

        public static IWebElement SafeFindElementBy(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(d => d.FindElement(by));
        }

        public static IWebElement SafeFindElementBy(this IWebDriver driver, IEnumerable<By> byCollection, double timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(d => d.FindFirstExistingElementFromCollection(byCollection));
        }

        private static IWebElement FindFirstExistingElementFromCollection(this IWebDriver driver, IEnumerable<By> byCollection)
        {
            foreach (var by in byCollection)
            {
                try { return driver.FindElement(by); } catch { }
            }

            throw new NoSuchElementException();
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
