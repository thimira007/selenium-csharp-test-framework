using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCsharp.Drivers;
using SeleniumCsharp.Pages;

namespace SeleniumCsharp.Tests
{
    public class HomePageTests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateDriver();
            homePage = new HomePage(driver);
        }

        [Test]
        public void ValidateHomePageTitle()
        {
            homePage.GoToHomePage();
            homePage.AcceptCookies();
            Assert.IsTrue(homePage.GetTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

    }
}
