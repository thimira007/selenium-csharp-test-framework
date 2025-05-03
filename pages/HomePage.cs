using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumCsharp.Utils;

namespace SeleniumCsharp.Pages
{
    public class HomePage : BasePage
    {
        private readonly By searchBox = By.XPath("//button[@id='onetrust-accept-btn-handler']");
        private readonly By menuHandla = By.CssSelector("[data-test='Handla']");
        private readonly By menuList = By.CssSelector(".tn-page-header__slide-down");
        private const string SubMenuItemXPathTemplate = "//*[@class='tn-page-header__slide-down']//li//*[text()='{0}']";

        public HomePage(IWebDriver driver) : base(driver) { }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl(Constants.HomePageUrl);
        }

        public void ClickMenuHandla()
        {
            ScrollToElement(menuHandla);
            ClickElement(menuHandla);
        }

        public void ClickSubMenuItem(string menuName)
        {
            string finalXPath = string.Format(SubMenuItemXPathTemplate, menuName);
            By menuItem = By.XPath(finalXPath);
            WaitUntilVisible(menuItem);
            ClickElement(menuItem);
        }

        public void AcceptCookies()
        {
            ClickElement(searchBox);
        }

    }
}
