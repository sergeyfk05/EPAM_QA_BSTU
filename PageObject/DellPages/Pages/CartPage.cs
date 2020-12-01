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
                List<Product> products = new List<Product>();

                IEnumerable<IWebElement> productContainers = _driver.FindElements(CartPageLocators.ProductContainer);

                foreach(var el in productContainers)
                {
                    products.Add(new Product(el));
                }

                return products;
            }
        }

    }
}
