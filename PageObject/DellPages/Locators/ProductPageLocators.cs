using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages.Locators
{
    public static class ProductPageLocators
    {
        public static readonly IEnumerable<By> AddToCartButtonLocators = new List<By>()
            {
                By.XPath("//*[@data-testid='addToCartButton']")
            };
        public static readonly IEnumerable<By> PriceTextLocators = new List<By>()
            {
                By.XPath("//div[@id='cf-strike-through-price']/div/div[@data-price]"),
                By.XPath("//*[@data-testid='sharedPSPDellPrice']")
            };
        public static readonly IEnumerable<By> ProductTitleLocators = new List<By>()
            {
                By.XPath("//h1[@class='cf-pg-title']"),
                By.XPath("//*[@id='page-title']/div/div/h1/span")
            };
        public static readonly IEnumerable<By> ElementConfirmingAddingToCart = new List<By>()
            {
                By.XPath("//h3[@id='cf-subtotal-label']"),
                By.XPath("//*[@data-soldout='false']")
            };
    }
}
