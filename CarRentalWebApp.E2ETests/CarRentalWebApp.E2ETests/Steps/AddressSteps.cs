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

        //how to search for field
        [Given(@"I enter login information:")]
        public void IEnterLoginInformation(Table table)
        {
            var emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys(table.Rows[0][1]);
            var passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys(table.Rows[1][1]);
        }

        [Given(@"I fill data information:")]
        public void GivenIFillDataInformation(Table table)
        {
            var cityNameField = driver.FindElement(By.Id("CityName"));
            cityNameField.SendKeys(table.Rows[0][1]);
            var streetNameField = driver.FindElement(By.Id("StreetName"));
            streetNameField.SendKeys(table.Rows[1][1]);
            var zipCodeField = driver.FindElement(By.Id("ZipCode"));
            zipCodeField.SendKeys(table.Rows[2][1]);
            var emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys(table.Rows[3][1]);
            var phoneNumber = driver.FindElement(By.Id("PhoneNumber"));
            phoneNumber.SendKeys(table.Rows[4][1]);
            var importanceLevel = driver.FindElement(By.Id("ImportanceLevel"));
            importanceLevel.Click();
            var importanceLevelRegularOption = table.Rows[5][1].ToString();
            By importanceLevelOptionSelector = null;
            switch (importanceLevelRegularOption)
            {
                case "VIP":
                    importanceLevelOptionSelector = AddressCreatePageModel.VipSelector;
                    break;
                case "Critical":
                    importanceLevelOptionSelector = AddressCreatePageModel.CriticalSelector;
                    break;
                case "Regular":
                    importanceLevelOptionSelector = AddressCreatePageModel.RegularSelector;
                    break;
            }
            PageModel.ClickButton(importanceLevelOptionSelector);


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
