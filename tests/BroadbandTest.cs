using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCsharp.Utils;
using SeleniumCsharp.Pages;


namespace SeleniumCsharp.Tests
{
    public class BroadbandTest : BaseTest
    {
        private HomePage homePage;
        private BroadbandPage broadbandPage;
        private const string addressSearchString = "Storgatan 1, Uppsala";

        [SetUp]
        public void init()
        {
            homePage = new HomePage(driver);
            broadbandPage = new BroadbandPage(driver);
        }


        [Test, Category("@smoke")]
        public void VerifyBredbandOptionAvailability()
        {
            homePage.NavigateToHomePage();
            homePage.AcceptCookies();
            homePage.ClickMenuHandla(); ;
            homePage.ClickSubMenuItem(Constants.MenuItemBredband);
            broadbandPage.SearchForAddress(addressSearchString);
            broadbandPage.SelectRandomApartment();

            IList<IWebElement> resultList = broadbandPage.GetProductResultsList();
            Assert.Greater(resultList.Count, 0, $"At least one result should be available. Found {resultList.Count} instead.");

            // verify Bredband via 5G option
            string searchText = "Bredband via 5G";
            bool isAvailable = broadbandPage.IsTextPresentInResultList(searchText);
            Assert.IsTrue(isAvailable, $"Text '{searchText}' was not found in any of the list items.");
        }

        // This is written expected to fail
        [Test]
        public void VerifyOtherOptionAvailability()
        {
            homePage.NavigateToHomePage();
            homePage.AcceptCookies();
            homePage.ClickMenuHandla(); ;
            homePage.ClickSubMenuItem(Constants.MenuItemBredband);
            broadbandPage.SearchForAddress(addressSearchString);
            broadbandPage.SelectRandomApartment();

            IList<IWebElement> resultList = broadbandPage.GetProductResultsList();
            Assert.Greater(resultList.Count, 0, $"At least one result should be available. Found {resultList.Count} instead.");

            // Check invalid value. it should fail the test
            string searchText = "Other via 5G";
            bool isAvailable = broadbandPage.IsTextPresentInResultList(searchText);
            Assert.IsTrue(isAvailable, $"Text '{searchText}' was not found in any of the list items.");
        }
    }
}
