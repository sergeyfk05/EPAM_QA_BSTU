using System;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Globalization;

namespace XUnitTestProject1
{
    public class DellTests
    {
        private readonly IWebDriver driver;
        public DellTests()
        {
            driver = new ChromeDriver();
        }

        ~DellTests()
        {
            driver?.Quit();
        }


        [Fact]
        public void AddingToCartTest()
        {
            //product page
            driver.Navigate().GoToUrl("https://www.dell.com/en-us/shop/cty/pdp/spd/xps-15-9500-laptop/xn9500cto210s");

            IWebElement addToCartButton = SafeFindElementByXpath(driver, "//button[@data-testid='addToCartButton']");

            AcceptCookies(driver);
            double ProductPageCost = Convert.ToDouble(SafeFindElementByXpath(driver, "//div[@id='cf-strike-through-price']/div/div[@data-price]").Text.Replace("$", ""), _costToDoubleConverterProvider);
            string ProductPageItemTitle = SafeFindElementByXpath(driver, "//h1[@class='cf-pg-title']").Text.Trim();

            addToCartButton.Click();

            SafeFindElementByXpath(driver, "//div[@id='cf-body']/div/h1/span[text()='Protect Your Purchases']");

            //cart page
            driver.Navigate().GoToUrl("https://www.dell.com/en-us/buy?cs=19");
            AcceptCookies(driver);
            var a = SafeFindElementByXpath(driver, "//span[@data-testid='itemssubtotalItemValue']/strong").Text;
            double CartPageCost = Convert.ToDouble(SafeFindElementByXpath(driver, "//span[@data-testid='itemssubtotalItemValue']/strong").Text.Replace("$", ""), _costToDoubleConverterProvider);
            string CartPageItemTitle = SafeFindElementByXpath(driver, "//div[@data-testid='itemTitle']").Text.Trim();
            int CartPageCountItems = Convert.ToInt32(SafeFindElementByXpath(driver, "//select[@name='repeatSelect']/option[@selected='selected']").Text);

            Assert.Equal(1, CartPageCountItems);
            Assert.Equal(ProductPageItemTitle, CartPageItemTitle);
            Assert.Equal(ProductPageCost, CartPageCost);
        }

        private void AcceptCookies(IWebDriver driver)
        {
            ReadOnlyCollection<IWebElement> cookieUsageAcceptButtons = driver.FindElements(By.XPath("//button[@id='_evidon-accept-button']"));
            if (cookieUsageAcceptButtons.Count > 0)
            {
                cookieUsageAcceptButtons[0].Click();
            }
        }

        private IWebElement SafeFindElementByXpath(IWebDriver driver, string xpath)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(120))
                .Until(d => d.FindElement(By.XPath(xpath)));
        }

        private static NumberFormatInfo _costToDoubleConverterProvider = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ",",
            NumberGroupSizes = new int[] { 3 }
        };
    }
}
