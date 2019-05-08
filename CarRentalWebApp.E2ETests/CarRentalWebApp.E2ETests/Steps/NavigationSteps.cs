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
        private IWebDriver driver;
        public NavigationSteps()
        {
            driver = WebDriverInstance.INSTANCE;
        }


        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["baseurl"]);
            IWebElement title = driver.FindElement(HomePageModel.TitleSelector);
            Assert.AreEqual("ASP.NET", title.Text);
        }

        [Given(@"I click ""(.*)"" button")]
        public void GivenIClickButton(string buttonText)
        {
            By buttonSelector = null;
            switch (buttonText)
            {
                case "Contact":
                    buttonSelector = HomePageModel.ContactSelector;
                    break;
                case "Go to calculator":
                    buttonSelector = HomePageModel.CalculatorSelector;
                    break;
                case "equals2":
                    buttonSelector = CalculatorPageModel.EqualSignSelector;
                    break;
                case "Log in navbar":
                    buttonSelector = NavbarModel.LogInSelector;
                    break;
                case "Log in":
                    buttonSelector = LogInPageModel.LogInButtonSelector;
                    break;
                case "Go to the list":
                    buttonSelector = HomePageModel.GoToTheListSelector;
                    break;
                case "Create New":
                    buttonSelector = AddressIndexPageModel.CreateNewSelector;
                    break;
                case "Create":
                    //sth
                    break;
                case "Log out":
                    //sth
                    break;
                default:
                    buttonSelector = HomePageModel.AboutSelector;
                    break;
            }

            PageModel.ClickButton(buttonSelector);
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
    }
}
