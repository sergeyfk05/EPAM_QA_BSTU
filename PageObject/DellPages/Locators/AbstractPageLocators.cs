using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages.Locators
{
    public static class AbstractPageLocators
    {
        public static readonly IEnumerable<By> CookieUsageAcceptButtonLocators = new List<By>()
            {
                By.XPath("//button[@id='_evidon-accept-button']")
            };
    }
}
