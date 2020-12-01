using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DellPages.Locators;

namespace DellPages.Pages
{
    public class CartPage : AbstractPage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        public override void Open()
        {
            _driver.Navigate().GoToUrl("https://www.dell.com/en-us/buy");
        }

        public double Subtotal => Convert.ToDouble(_driver.SafeFindElementBy(CartPageLocators.Subtotal).Text.Replace("$", ""),
                Helpers.CostToDoubleConverterProvider);

        public IEnumerable<Product> Products
        {
            get
            {
                List<double> subtotals = _driver.FindElements(By.XPath(CartPageLocators.ProductContainerXPath + CartPageLocators.ProductSubtotalXPath))
                    .Select(x => Convert.ToDouble(x.Text.Replace("$", ""), Helpers.CostToDoubleConverterProvider)).ToList();
                List<string> titles = _driver.FindElements(By.XPath(CartPageLocators.ProductContainerXPath + CartPageLocators.ProductTitleXPath))
                    .Select(x => x.Text).ToList();
                List<int> counts = _driver.FindElements(By.XPath(CartPageLocators.ProductContainerXPath + CartPageLocators.ProductCountXPath))
                    .Select(x => Convert.ToInt32(x.Text)).ToList();

                List<Product> products = new List<Product>();

                for(int i=0; i < subtotals.Count(); i++)
                {
                    products.Add(new Product()
                    {
                        Count = counts[i],
                        Subtotal = subtotals[i],
                        Title = titles[i]
                    });
                }

                return products;
            }
        }

    }
}
