using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellPages.Locators
{
    public static class ProductContainerInCart
    {
        public static readonly string ProductSubtotalXPath = "//*[@data-testid='itemTotalAmount']";
        public static readonly By ProductSubtotal = By.XPath(ProductSubtotalXPath);

        public static readonly string ProductCountXPath = "//select[@name='repeatSelect']/option[@selected='selected']";
        public static readonly By ProductCount = By.XPath(ProductCountXPath);

        public static readonly string ProductTitleXPath = "//*[@data-testid='itemTitle']";
        public static readonly By ProductTitle = By.XPath(ProductTitleXPath);
        
        public static readonly string ProductRemoveButtonXpath = "//*[@data-testid='cartRemoveItemAction']";
        public static readonly By ProductRemoveButton = By.XPath(ProductRemoveButtonXpath);
    }
}
