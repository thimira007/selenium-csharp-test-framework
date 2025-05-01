using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCsharp.Pages
{
    public class BroadbandPage
    {
        private readonly IWebDriver driver;
        //private readonly By searchBox = By.Id("onetrust-accept-btn-handler");
        private readonly By searchBox = By.XPath("//button[@id='onetrust-accept-btn-handler']");


        public BroadbandPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public void navigateToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.telenor.se/");
        }
    }
}
