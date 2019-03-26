using OpenQA.Selenium;
namespace CarRentalWebApp.E2ETests.Models
{
    public class PageModel
    {
        protected IWebDriver driver = WebDriverInstance.INSTANCE;
        public void ClickButton(By selector)
        {
            IWebElement button = driver.FindElement(selector);
            button.Click();
        }
    }
}
