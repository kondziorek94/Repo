using CarRentalWebApp.E2ETests.Models;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    class ContactSteps
    {
        private IWebDriver driver = WebDriverInstance.INSTANCE;
        private ContactPageModel contactPageModel;
        NavigationSteps NavigationSteps = new NavigationSteps();

        public ContactSteps()
        {
            contactPageModel = new ContactPageModel();
            driver = WebDriverInstance.INSTANCE;
        }

    }
}
