using CarRentalWebApp.E2ETests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    class AddressSteps
    {
        private IWebDriver driver;
        public AddressSteps(IWebDriver driver)
        {
           this.driver = driver;
        }

        [Given(@"I enter login information:")]
        public void IEnterLoginInformation(Table table)
        {
            var emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys(table.Rows[0][1]);
            var passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys(table.Rows[1][1]);
        }

        [Given(@"I fill data information:")]
        [Given(@"I correct data information:")]
        public void GivenIFillDataInformation(Table table)
        {
            var cityNameField = driver.FindElement(By.Id("CityName"));
            cityNameField.Clear();
            cityNameField.SendKeys(table.Rows[0][1]);
            var streetNameField = driver.FindElement(By.Id("StreetName"));
            streetNameField.Clear();
            streetNameField.SendKeys(table.Rows[1][1]);
            var zipCodeField = driver.FindElement(By.Id("ZipCode"));
            zipCodeField.Clear();
            zipCodeField.SendKeys(table.Rows[2][1]);
            var emailField = driver.FindElement(By.Id("Email"));
            emailField.Clear();
            emailField.SendKeys(table.Rows[3][1]);
            var phoneNumber = driver.FindElement(By.Id("PhoneNumber"));
            phoneNumber.Clear();
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
            
            driver.FindElement(importanceLevelOptionSelector).Click();
            ScenarioContext.Current["Email"] = table.Rows[3][1];
        }

        [Given(@"I check if there are ""(.*)"" validation error\(s\)")]
        public void GivenICheckIfThereAreValidationErrorS(int numberOfErrors)
        {
            List<IWebElement> errors = new List<IWebElement>();
            try
            {
                errors.Add(driver.FindElement(By.Id("PhoneNumber-error")));
                errors.Add(driver.FindElement(By.Id("Email-error")));
            }
            catch (NoSuchElementException) { }
            Assert.AreEqual(numberOfErrors, errors.Count);
        }

        [Given(@"I fill search information in")]
        public void GivenIFillSearchInformationIn(Table table)
        {
            var searchBox = driver.FindElement(By.Id("addressLookUp"));
            searchBox.SendKeys(table.Rows[0][1]);
            searchBox.SendKeys(Keys.Enter);
        }

        [Given(@"I check if the list contain specific address ""(.*)""")]
        [Given(@"I check if address does not exists ""(.*)""")]
        public void GivenICheckIfTheListContainSpecificAddress(bool expectedValue)
        {
            var AddressesListTable = driver.FindElement(By.Id("addressesListTable"));
            IList<IWebElement> tableRow = AddressesListTable.FindElements(By.TagName("tr"));
            bool actualFound = false;
            foreach (var row in tableRow)
            {
                if (row.Text.Contains("Lublin") && row.Text.Contains("Nadbystrzycka") && row.Text.Contains("21-024") && row.Text.Contains("923-231-432"))
                {
                    actualFound = true;
                }
            }
            Assert.AreEqual(expectedValue, actualFound);
        }

        [Given(@"I delete created address")]
        public void GivenIDeleteAddress()
        {
            var emailToSearch = ScenarioContext.Current["Email"];
            var searchBox = driver.FindElement(By.Id("addressLookUp"));
            searchBox.Clear();
            searchBox.SendKeys(emailToSearch.ToString());
            searchBox.SendKeys(Keys.Enter);
            driver.FindElement(AddressIndexPageModel.DeleteSelector).Click();
            driver.FindElement(AddressDeletePageModel.DeleteSelector).Click();
        }
    }
}