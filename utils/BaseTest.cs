using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumCsharp.Utils
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            // Runs once before all tests in the class (optional)
            // e.g., initialize reporting or environment config
        }

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            // Runs once after all tests in the class (optional)
            // e.g., flush reports
        }
    }
}
