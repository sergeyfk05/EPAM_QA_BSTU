using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DellPages.Locators;
using System.Threading;

namespace DellPages
{
    public class Product
    {
        IWebElement _container;
        public Product(IWebElement container)
        {
            _container = container;
        }
        public string Title => _container.FindElement(ProductContainerInCart.ProductTitle).Text;
        public int Count => Convert.ToInt32(_container.FindElement(ProductContainerInCart.ProductCount).Text);
        public double Subtotal => Convert.ToDouble(_container.FindElement(ProductContainerInCart.ProductSubtotal).Text.Replace("$", ""), 
            Helpers.CostToDoubleConverterProvider);

        private IWebElement _removeButton => _container.FindElements(ProductContainerInCart.ProductRemoveButton).First(x => x.Displayed);

        public void Remove()
        {
            _removeButton.Click();
            Thread.Sleep(1500);
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Title == product.Title &&
                   Count == product.Count &&
                   Subtotal == product.Subtotal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Count, Subtotal);
        }
    }
}
