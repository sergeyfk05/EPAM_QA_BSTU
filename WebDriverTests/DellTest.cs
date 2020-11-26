using System;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Globalization;
using WebDriverTests;

namespace WebDriverTests
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


        [Theory]
        [InlineData("https://www.dell.com/en-us/shop/cty/pdp/spd/xps-15-9500-laptop/xn9500cto210s")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-ultrasharp-32-8k-monitor-up3218k/apd/210-alez/monitors-monitor-accessories")]
        [InlineData("https://www.dell.com/en-us/shop/dell-laptops/new-dell-g7-17-gaming-laptop/spd/g-series-17-7700-laptop/gn7700ehyyh")]
        public void AddingToCartTest(string productLink)
        {
            //product page
            driver.Navigate().GoToUrl(productLink);

            IWebElement addToCartButton = driver.SafeFindElementByXpath("//*[@data-testid='addToCartButton']");

            driver.AcceptCookies();
            double ProductPageCost = Convert.ToDouble(driver.SafeFindElementByXpath("//div[@id='cf-strike-through-price']/div/div[@data-price]").Text.Replace("$", ""), Helpers.CostToDoubleConverterProvider);
            string ProductPageItemTitle = driver.SafeFindElementByXpath("//h1[@class='cf-pg-title']").Text.Trim();

            addToCartButton.Click();

            driver.SafeFindElementByXpath("//div[@id='cf-body']/div/h1/span[text()='Protect Your Purchases']");

            //cart page
            driver.Navigate().GoToUrl("https://www.dell.com/en-us/buy?cs=19");
            double CartMobilePageCost = Convert.ToDouble(driver.SafeFindElementByXpath("//*[@data-testid='itemssubtotalItemValue']").GetHiddenText(driver).Replace("$", ""), Helpers.CostToDoubleConverterProvider);
            double CartDesktopPageCost = Convert.ToDouble(driver.SafeFindElementByXpath("//*[@data-testid='cartSubtotal']").GetHiddenText(driver).Replace("$", ""), Helpers.CostToDoubleConverterProvider);
            string CartPageItemTitle = driver.SafeFindElementByXpath("//*[@data-testid='itemTitle']").Text.Trim();
            int CartPageCountItems = Convert.ToInt32(driver.SafeFindElementByXpath("//select[@name='repeatSelect']/option[@selected='selected']").Text);

            Assert.Equal(1, CartPageCountItems);
            Assert.Equal(ProductPageItemTitle, CartPageItemTitle);
            Assert.Equal(ProductPageCost, CartMobilePageCost);
            Assert.Equal(ProductPageCost, CartDesktopPageCost);
        }






    }
}
