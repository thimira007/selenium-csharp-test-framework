using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumCsharp.Utils
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Scroll to an element
        protected void ScrollToElement(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        // Click element safely
        protected void ClickElement(By locator)
        {
            WaitUntilClickable(locator).Click();
        }

        // Enter text into field
        protected void EnterText(By locator, string text)
        {
            var element = WaitUntilVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        // Get text from element
        protected string GetText(By locator)
        {
            return WaitUntilVisible(locator).Text;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        // Wait until an element is visible
        protected IWebElement WaitUntilVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Wait until an element is clickable
        protected IWebElement WaitUntilClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
