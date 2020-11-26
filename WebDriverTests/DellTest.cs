using System;
using Xunit;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Globalization;
using WebDriverTests;
using System.Collections.Generic;

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
        //[InlineData("https://www.dell.com/en-us/shop/cty/pdp/spd/xps-15-9500-laptop/xn9500cto210s")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-ultrasharp-32-8k-monitor-up3218k/apd/210-alez/monitors-monitor-accessories")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-laptops/new-dell-g7-17-gaming-laptop/spd/g-series-17-7700-laptop/gn7700ehyyh")]
        [InlineData("https://www.dell.com/en-us/shop/new-alienware-low-profile-rgb-mechanical-gaming-keyboard-aw510k/apd/580-aimo/pc-accessories")]
        //[InlineData("https://www.dell.com/en-us/shop/desktop-computers/new-inspiron-24-5000-black-all-in-one-with-bipod-stand/spd/inspiron-24-5400-aio/na5400ekphh")]
        //[InlineData("https://www.dell.com/en-us/shop/makerbot-replicator-3d-printer/apd/a9231730/printers-ink-toner")] 
        public void AddingToCartTest(string productLink)
        {
            //product page
            driver.Navigate().GoToUrl(productLink);

            IWebElement addToCartButton = driver.SafeFindElementBy(By.XPath("//*[@data-testid='addToCartButton']"));

            driver.AcceptCookies();            
            double ProductPageCost = Convert.ToDouble(driver.SafeFindElementBy(new List<By>()
            {
                By.XPath("//div[@id='cf-strike-through-price']/div/div[@data-price]"),
                By.XPath("//*[@data-testid='sharedPSPDellPrice']")
            }).Text.Replace("$", ""), 
            Helpers.CostToDoubleConverterProvider);            
            
            string ProductPageItemTitle = driver.SafeFindElementBy(new List<By>()
            {
                By.XPath("//h1[@class='cf-pg-title']"),
                By.XPath("//*[@id='page-title']/div/div/h1/span")
            }).Text.Trim();


            addToCartButton.Click();

            driver.SafeFindElementBy(By.XPath("//h3[@id='cf-subtotal-label']"));

            //cart page
            driver.Navigate().GoToUrl("https://www.dell.com/en-us/buy?cs=19");
            double CartPageCost = Convert.ToDouble(driver.SafeFindElementBy(new List<By>()
            {
                By.XPath("//*[@data-testid='itemssubtotalItemValue']"),
                By.XPath("//*[@data-testid='cartSubtotal']")
            }).GetHiddenText(driver).Replace("$", ""),
            Helpers.CostToDoubleConverterProvider);

            string CartPageItemTitle = driver.SafeFindElementBy(By.XPath("//*[@data-testid='itemTitle']")).Text.Trim();
            int CartPageCountItems = Convert.ToInt32(driver.SafeFindElementBy(By.XPath("//select[@name='repeatSelect']/option[@selected='selected']")).Text);

            Assert.Equal(1, CartPageCountItems);
            Assert.Equal(ProductPageItemTitle, CartPageItemTitle);
            Assert.Equal(ProductPageCost, CartPageCost);
        }






    }
}
