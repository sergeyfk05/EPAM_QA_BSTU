using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace DellTests
{
    public class UnitTest1
    {
        private readonly IWebDriver driver;
        public UnitTest1()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(150));
        }

        public void Dispose()
        {
            driver?.Quit();
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
