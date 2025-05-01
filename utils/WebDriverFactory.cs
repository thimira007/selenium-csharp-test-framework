using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TelenorAutomation.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
