using CarRentalWebApp.E2ETests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    class AddressSteps
    {
        private IWebDriver driver;
        public AddressSteps()
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
        //Distinguish 2 buttons with the same name
        [Given(@"I click ""(.*)"" button")]
        [Then(@"I click ""(.*)"" button")]
        public void GivenIClickButton(string buttonText)
        {
            By buttonSelector;
            switch (buttonText)
            {
                case "Log in":
                    buttonSelector = HomePageModel.ContactSelector;
                    break;
                case "Go to the list":
                    buttonSelector = HomePageModel.CalculatorSelector;
                    break;
                case "Create New":
                    buttonSelector = CalculatorPageModel.EqualSignSelector;
                    break;
                case "Create":
                    buttonSelector = CalculatorPageModel.EqualSignSelector;
                    break;
                case "Log out":
                    buttonSelector = CalculatorPageModel.EqualSignSelector;
                    break;
                default:
                    buttonSelector = HomePageModel.AboutSelector;
                    break;
            }

        }
        //how to search for field
        [Given(@"I enter login information:")]
        public void IEnterLoginInformation(string login, string password)
        {

            var q = driver.FindElement(By.Id("loginLink"));
            q.Click();
        }
        [Given(@"And I check if there are ""(.*)"" validation error(s)")]
        public void AndICheckIfThereAreValidationErrors(int numberOfErrors)
        {

        }
        [Given(@"And I correct data information")]
        public void AndICorrectDataInformation()
        {

        }
        [Given(@"And I fill search information in")]
        public void AndIFillSearchInformationIn()
        {

        }
        [Given(@"And I check if the list contain specific address")]
        public void AndICheckIfTheListContainSpecificAddress()
        {

        }
        [Given(@"And I delete address")]
        public void AndIDeleteAddress()
        {

        }
        [Given(@"And I check if address does not exists")]
        public void AndICheckIfAddressDoesNotExists()
        {

        }
    }
}

/*
	And I enter login information:
	|Field|Value|
	|Email|a@a.pl|
	|Password|Password2@|
	And I click "Log in" button
	And I click "Go to the list" button
	And I click "Create New" link
	And I fill data information:
	| Field       | Value         |
	| CityName    | Lublin        |
	| StreetName  | Nadbystrzycka |
	| ZipCode     | 21-024        |
	| Email       | asjv          |
	| PhoneNumber | 2014321920    |
	And I check if there are "2" validation error(s)
	And I click "Create" button
	And I correct data information:
	| Field       | Value         |
	| CityName    | Lublin        |
	| StreetName  | Nadbystrzycka |
	| ZipCode     | 21-024        |
	| Email       | kbudny492@gmail.com          |
	| PhoneNumber | 923-231-432    |
	And I click "Create" button
	And I fill search information in
	| Field         | value  |
	| addressLookUp | Lublin |
	And I check if the list contain specific address
	
	And I delete address
	And I check if address does not exists

*/
