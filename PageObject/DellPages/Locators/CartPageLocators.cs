using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages.Locators
{
    public static class CartPageLocators
    {
        public static readonly IEnumerable<By> Subtotal = new List<By>()
            {
                By.XPath("//*[@data-testid='itemssubtotalItemValue']"),
                By.XPath("//*[@data-testid='cartSubtotal']")
            };

        public static readonly string ProductContainerXPath = "//div[starts-with(@ng-repeat, 'item in DataModel.CartItems')]";
        public static readonly By ProductContainer = By.XPath(ProductContainerXPath);
    }
}
