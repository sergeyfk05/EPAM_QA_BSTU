using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverTests.ElementFilters
{
    public static class CartPageElementFilters
    {
        public static readonly IEnumerable<By> SubtotalCost = new List<By>()
            {
                By.XPath("//*[@data-testid='itemssubtotalItemValue']"),
                By.XPath("//*[@data-testid='cartSubtotal']")
            };
        public static readonly IEnumerable<By> ProductCount = new List<By>()
            {
                By.XPath("//select[@name='repeatSelect']/option[@selected='selected']")
            };
        public static readonly IEnumerable<By> ProductTitle = new List<By>()
            {
                By.XPath("//*[@data-testid='itemTitle']")
            };
    }
}
