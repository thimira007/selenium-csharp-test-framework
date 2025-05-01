using OpenQA.Selenium;

namespace SeleniumCsharp.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly By searchBox = By.Id("onetrust-accept-btn-handler"); // Example: Cookie Accept

        public HomePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.telenor.se/");
        }

        public void AcceptCookies()
        {
            try
            {
                driver.FindElement(searchBox).Click();
            }
            catch (NoSuchElementException) { }
        }

        public string GetTitle()
        {
            return driver.Title;
        }
    }
}
