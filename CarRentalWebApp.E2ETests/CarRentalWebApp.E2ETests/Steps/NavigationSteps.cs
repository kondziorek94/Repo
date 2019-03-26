using CarRentalWebApp.E2ETests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
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
            By buttonSelector;
            switch (buttonText)
            {
                case "Contact":
                    buttonSelector = HomePageModel.ContactSelector;
                    break;
                case "Go to calculator":
                    buttonSelector = HomePageModel.CalculatorSelector;
                    break;
                case "equals2":
                    buttonSelector = CalculatorPageModel.EqualSignId;
                    break;
                default:
                    buttonSelector = HomePageModel.AboutSelector;
                    break;
            }

            homePageModel.ClickButton(buttonSelector);
        }

        [Then(@"I see ""(.*)"" page")]
        public void ThenISeePage(string pageName)
        {
            By titleSelector;
            string expectedValue = "";
            switch (pageName)
            {
                case "Contact":
                    titleSelector = ContactPageModel.Title;
                    expectedValue = "Contact.";
                    break;
                default:
                    titleSelector = AboutPageModel.Title;
                    expectedValue = "About.";
                    break;
            }
            string titleText = driver.FindElement(titleSelector).Text;

            Assert.AreEqual(expectedValue, titleText);
        }
        [Then(@"I check the result")]
        public void ICheckTheResult()
        {
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
            string expectedValue = "2 + 5";
            string actualValue = driver.FindElement(CalculatorPageModel.DisplayId).Text;
            Assert.AreEqual(expectedValue, actualValue);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

    }
}
