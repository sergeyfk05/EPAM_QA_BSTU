using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using DellPages.Locators;

namespace DellPages.Pages
{
    public class AddedToCartPage : AbstractPage
    {
        public AddedToCartPage(IWebDriver driver) : base(driver) { }

        public override void Open()
        {
            throw new InvalidOperationException();
        }

        public double Subtotal => Convert.ToDouble(_driver.SafeFindElementBy(AddedToCartPageLocators.SubtotalTextLocators).Text.Replace("$", ""),
                Helpers.CostToDoubleConverterProvider);
    }
}
