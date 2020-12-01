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

        public static readonly string ProductSubtotalXPath = "//*[@data-testid='itemTotalAmount']";
        public static readonly IEnumerable<By> ProductSubtotal = new List<By>()
            {
                By.XPath(ProductSubtotalXPath)
            };

        public static readonly string ProductCountXPath = "//select[@name='repeatSelect']/option[@selected='selected']";
        public static readonly IEnumerable<By> ProductCount = new List<By>()
            {
                By.XPath(ProductCountXPath)
            };

        public static readonly string ProductTitleXPath = "//*[@data-testid='itemTitle']";
        public static readonly IEnumerable<By> ProductTitle = new List<By>()
            {
                By.XPath(ProductTitleXPath)
            };

        public static readonly string ProductContainerXPath = "//div[starts-with(@ng-repeat, 'item in DataModel.CartItems')]";
        public static readonly IEnumerable<By> ProductContainer = new List<By>()
            {
                By.XPath(ProductContainerXPath)
            };
}
}
