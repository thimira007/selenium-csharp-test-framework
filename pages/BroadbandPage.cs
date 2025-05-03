using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using SeleniumCsharp.Utils;

namespace SeleniumCsharp.Pages
{
    public class BroadbandPage : BasePage
    {
        private readonly By searchBox = By.XPath("//div[@data-test='address-search-input']//input");
        private readonly By addressList = By.Id("address-list");
        private const string addressListItem = "//ul[@id='address-list']//li[text()='{0}']";
        private readonly By dropdownApartment = By.Id("tnid-1-select");
        private readonly By apartmentResultsList = By.XPath("//select[@id='tnid-7-select']");
        private readonly By productResultsList = By.XPath("//div[@data-test='product-grid']/ul");
        private readonly By productResultTitle = By.XPath("//*[@data-test='grid-item-heading']");

        public BroadbandPage(IWebDriver driver) : base(driver) { }

        public void SearchForAddress(string address)
        {
            WaitUntilVisible(searchBox);
            EnterText(searchBox, address);
            WaitUntilVisible(addressList);
            string finalXPath = string.Format(addressListItem, address.ToUpper());
            By searchResult = By.XPath(finalXPath);
            WaitUntilVisible(searchResult);
            ClickElement(searchResult);
        }

        public void SelectRandomApartment()
        {
            IWebElement dropdown = driver.FindElement(dropdownApartment);
            SelectElement select = new SelectElement(dropdown);
            // Get the options count
            var options = select.Options;
            int count = options.Count;
            int randomNumber = Helpers.GetRandomIndex(0, count - 1);
            //select.SelectByIndex(randomNumber);

            // Default select does not work here. Hence finding an alternative way to select the apartment
            ClickElement(dropdownApartment);
            Actions actions = new Actions(driver);
            for (int i = 0; i < randomNumber; i++)
            {
                actions.SendKeys(Keys.ArrowDown);
            }
            actions.SendKeys(Keys.Enter)
                       .Build()
                       .Perform();
        }

        public IList<IWebElement> GetProductResultsList()
        {
            IWebElement ulElement = driver.FindElement(productResultsList);
            IList<IWebElement> listItems = ulElement.FindElements(By.TagName("li"));
            return listItems;
        }

        public bool IsTextPresentInResultList(string searchText)
        {
            IList<IWebElement> resultList = GetProductResultsList();
            foreach (var listItem in resultList)
            {
                var headingElement = listItem.FindElement(productResultTitle);
                if (headingElement.Text.Contains(searchText))
                {
                    return true;
                }
            }
            return false;
        }
    }
}