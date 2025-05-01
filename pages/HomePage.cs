using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumCsharp.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        //private readonly By searchBox = By.Id("onetrust-accept-btn-handler");
        private readonly By searchBox = By.XPath("//button[@id='onetrust-accept-btn-handler']");
        private readonly By menuHandla = By.CssSelector("[data-test='Handla']");
        private readonly By menuList = By.CssSelector(".tn-page-header__slide-down");


        public HomePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public void navigateToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.telenor.se/");
        }

        public void clickMenuHandla()
        {
            ScrollToElement(menuHandla);
            driver.FindElement(menuHandla).Click();
        }

        public void clickSubMenuItem(string menuName)
        {
            By menuItem = By.XPath($"//*[@class='tn-page-header__slide-down']//li//*[text()='{menuName}']");
            WaitUntilElementIsVisible(menuItem);
            driver.FindElement(menuItem).Click();
        }

        public void acceptCookies()
        {
                driver.FindElement(searchBox).Click();
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public void ScrollToElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void WaitUntilElementIsVisible(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
