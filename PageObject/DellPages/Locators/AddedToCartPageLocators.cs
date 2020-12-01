using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages.Locators
{
    public class AddedToCartPageLocators
    {
        public static readonly IEnumerable<By> SubtotalTextLocators = new List<By>()
            {
                By.XPath("//*[@data-price]")
            };
    }
}
