using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCsharp.Utils;
using SeleniumCsharp.Pages;


namespace SeleniumCsharp.Tests
{
    public class HomePageTests : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void init()
        {
            homePage = new HomePage(driver);
        }


        [Test, Category("@smoke")]
        public void ValidateHomePageTitle()
        {
            homePage.NavigateToHomePage();
            homePage.AcceptCookies();
            Assert.IsTrue(homePage.GetPageTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
            homePage.ClickMenuHandla(); ;
            homePage.ClickSubMenuItem("Bredband");
        }

        [Test]
        public void ValidateHomePageTitle1()
        {
            homePage.NavigateToHomePage();
            homePage.AcceptCookies();
            Assert.IsTrue(homePage.GetPageTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
            homePage.ClickMenuHandla(); ;
            homePage.ClickSubMenuItem("Bredband");
        }
    }
}
