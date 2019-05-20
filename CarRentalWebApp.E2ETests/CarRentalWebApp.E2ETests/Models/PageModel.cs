using OpenQA.Selenium;

namespace CarRentalWebApp.E2ETests.Models
{
    public class PageModel
    {
        protected static IWebDriver Driver => WebDriverInstance.INSTANCE;
        public static void ClickButton(By selector)
        {
            IWebElement button = Driver.FindElement(selector);
            button.Click();
        }
    }
}