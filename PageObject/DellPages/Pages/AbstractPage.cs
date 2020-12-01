using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DellPages.Locators;

namespace DellPages.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver _driver;
        public AbstractPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _cookieUsageAcceptButton => Helpers.SafeFindElementBy(_driver, AbstractPageLocators.CookieUsageAcceptButtonLocators);

        public void AcceptCookies()
        {
            _cookieUsageAcceptButton?.Click();
        }

        public virtual void Open()
        {
            throw new NotImplementedException();
        }
    }
}
