using CarRentalWebApp.E2ETests.Models;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver driver;

        [Before]
        public void BeforeScenario()
        {
            WebDriverInstance.Reinstiate();
            driver = WebDriverInstance.INSTANCE;
        }

        [After]
        public void AfterScenario()
        {
            driver.Dispose();
        }
    }
}