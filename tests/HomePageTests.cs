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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            homePage = new HomePage(driver);
        }

        [Test, Category("@smoke")]
        public void ValidateHomePageTitle()
        {
            homePage.navigateToHomePage();
            homePage.acceptCookies();
            Assert.IsTrue(homePage.getTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
            homePage.clickMenuHandla();;
            homePage.clickSubMenuItem("Bredband");
        }

        //[Test]
        //public void ValidateHomePageTitle1()
        //{
        //    homePage.navigateToHomePage();
        //    homePage.acceptCookies();
        //    Assert.IsTrue(homePage.getTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
        //}

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

    }
}
