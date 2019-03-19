using CarRentalWebApp.E2ETests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private HomePageModel homePageModel;
        private IWebDriver driver;
        public NavigationSteps()
        {
            homePageModel = new HomePageModel();
            driver = WebDriverInstance.INSTANCE;
        }


        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseurl"]);
            IWebElement title = driver.FindElement(HomePageModel.TitleSelector);
            Assert.AreEqual("ASP.NET", title.Text);
        }

        [Given(@"I clicked ""(.*)"" button")]
        public void GivenIClickedButton(string buttonText)
        {
            By buttonSeletor;
            switch (buttonText)
            {
                default:
                    buttonSeletor = HomePageModel.AboutSelector;
                    break;
            }

            homePageModel.ClickButton(buttonSeletor);
        }

        [Then(@"I see ""(.*)"" page")]
        public void ThenISeePage(string title)
        {
            By titleSelector;
            switch (title)
            {
                default:
                    titleSelector = AboutPageModel.Title;
                    break;
            }
            string titleText = driver.FindElement(titleSelector).Text;
            Assert.AreEqual("About.", titleText);
        }

    }
}
