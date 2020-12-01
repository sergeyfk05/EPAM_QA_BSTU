using DellPages.Locators;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages.Pages
{
    public class ProductPage : AbstractPage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public string Link { get; internal set; }

        private IWebElement _addToCartButton => Helpers.SafeFindElementBy(_driver, ProductPageLocators.AddToCartButtonLocators);

        public AddedToCartPage AddToCart()
        {
            _addToCartButton?.Click();
            _driver.SafeFindElementBy(ProductPageLocators.ElementConfirmingAddingToCart);
            return new AddedToCartPage(_driver);
        }

        public double Price => Convert.ToDouble(_driver.SafeFindElementBy(ProductPageLocators.PriceTextLocators).Text.Replace("$", ""),
                Helpers.CostToDoubleConverterProvider);

        public string Title => _driver.SafeFindElementBy(ProductPageLocators.ProductTitleLocators).GetHiddenText(_driver).Trim();

        public override void Open()
        {
            _driver.Navigate().GoToUrl(Link);
        }
    }
}
