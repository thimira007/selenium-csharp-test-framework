using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCsharp.Utils;
using SeleniumCsharp.Pages;


namespace SeleniumCsharp.Tests
{
    public class HomePageTests : BaseTest
    {
        private HomePage homePage;
        private BroadbandPage broadbandPage;

        [SetUp]
        public void init()
        {
            homePage = new HomePage(driver);
            broadbandPage = new BroadbandPage(driver);
        }


        [Test, Category("@smoke")]
        public void ValidateHomePageTitle()
        {
            homePage.NavigateToHomePage();
            homePage.AcceptCookies();
            Assert.IsTrue(homePage.GetPageTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
            homePage.ClickMenuHandla(); ;
            homePage.ClickSubMenuItem(Constants.MenuItemBredband);
            broadbandPage.SearchForAddress("Storgatan 1, Uppsala");
            broadbandPage.SelectRandomApartment();

            IList<IWebElement> resultList = broadbandPage.GetProductResultsList();
            Assert.Greater(resultList.Count, 0, $"At least one result should be available. Found {resultList.Count} instead.");

            // verify Bredband via 5G option
            string searchText = "Bredband via 5G";
            bool isAvailable = broadbandPage.IsTextPresentInResultList(searchText);
            Assert.IsTrue(isAvailable, $"Text '{searchText}' was not found in any of the list items.");
        }

        [Test]
        public void ValidateHomePageTitle1()
        {
            homePage.NavigateToHomePage();
            homePage.AcceptCookies();
            Assert.IsTrue(homePage.GetPageTitle().Contains("Telenor"), "Homepage title should contain 'Telenor'");
            homePage.ClickMenuHandla(); ;
            homePage.ClickSubMenuItem(Constants.MenuItemBredband);
        }
    }
}
