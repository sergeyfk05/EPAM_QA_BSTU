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
using WebDriverTests.ElementLocators;

namespace WebDriverTests
{
    public class DellTests : IDisposable
    {
        private readonly IWebDriver driver;
        public DellTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(150));
        }

        public void Dispose()
        {
            driver?.Quit();
        }


        [Theory]
        [InlineData("https://www.dell.com/en-us/shop/cty/pdp/spd/xps-15-9500-laptop/xn9500cto210s")]
        [InlineData("https://www.dell.com/en-us/shop/dell-ultrasharp-32-8k-monitor-up3218k/apd/210-alez/monitors-monitor-accessories")]
        [InlineData("https://www.dell.com/en-us/shop/dell-laptops/new-dell-g7-17-gaming-laptop/spd/g-series-17-7700-laptop/gn7700ehyyh")]
        [InlineData("https://www.dell.com/en-us/shop/new-alienware-low-profile-rgb-mechanical-gaming-keyboard-aw510k/apd/580-aimo/pc-accessories")]
        [InlineData("https://www.dell.com/en-us/shop/desktop-computers/new-inspiron-24-5000-black-all-in-one-with-bipod-stand/spd/inspiron-24-5400-aio/na5400ekphh")]
        [InlineData("https://www.dell.com/en-us/shop/dell-laptops/alienware-m17-r3-gaming-laptop/spd/alienware-m17-r3-laptop/wnm17r312sbf")]
        [InlineData("https://www.dell.com/en-us/shop/desktop-computers/inspiron-desktop/spd/inspiron-3880-desktop/nd3880eejks")]
        [InlineData("https://www.dell.com/en-us/shop/dell-urban-backpack-15/apd/460-bbyl/carrying-cases")]
        [InlineData("https://www.dell.com/en-us/shop/kensington-ld4650p-usb-c-universal-dock-with-k-fob-smart-lock-docking-station-usb-c-gige-north-america/apd/aa659274/pc-accessories")]
        [InlineData("https://www.dell.com/en-us/shop/dell-32-curved-gaming-monitor-s3220dgf/apd/210-atyt/monitors-monitor-accessories")]
        [InlineData("https://www.dell.com/en-us/shop/pny-nvidia-quadro-rtx-6000-graphics-card-24-gb-gddr6-pcie-30-x16-4-x-displayport-usb-c/apd/aa413562/graphic-video-cards")]
        [InlineData("https://www.dell.com/en-us/shop/samsung-98-inch-tv-2020-qled-8k-ultra-hd-hdr10-smart-tv-q900-series-qn98q900rbfxza/apd/ab168598/tv-home-theater")]
        public void AddingToCartTest(string productLink)
        {
            //product page
            
            driver.Navigate().GoToUrl(productLink);

            IWebElement addToCartButton = driver.SafeFindElementBy(ProductPageElementLocators.AddToCartButton);

            driver.AcceptCookies();            
            double ProductPageCost = Convert.ToDouble(driver.SafeFindElementBy(ProductPageElementLocators.PriceText).Text.Replace("$", ""),
                Helpers.CostToDoubleConverterProvider);            
            
            string ProductPageItemTitle = driver.SafeFindElementBy(ProductPageElementLocators.ProductTitle).GetHiddenText(driver).Trim();


            addToCartButton.Click();

            driver.SafeFindElementBy(ProductPageElementLocators.ElementConfirmingAddingToCart);

            //cart page
            driver.Navigate().GoToUrl("https://www.dell.com/en-us/buy?cs=19");
            double CartPageCost = Convert.ToDouble(driver.SafeFindElementBy(CartPageElementLocators.SubtotalCost).GetHiddenText(driver).Replace("$", ""),
                Helpers.CostToDoubleConverterProvider);

            string CartPageProductTitle = driver.SafeFindElementBy(CartPageElementLocators.ProductTitle).GetHiddenText(driver).Trim();
            int CartPageCountItems = Convert.ToInt32(driver.SafeFindElementBy(CartPageElementLocators.ProductCount).Text);

            Assert.Equal(1, CartPageCountItems);
            Assert.Equal(ProductPageCost, CartPageCost);
            Assert.Equal(ProductPageItemTitle.ToUpper(), CartPageProductTitle.ToUpper());

            this.Dispose();
        }


    }
}
