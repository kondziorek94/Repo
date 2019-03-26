using CarRentalWebApp.E2ETests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    public class CalculatorSteps
    {

        private IWebDriver driver;
        public CalculatorSteps()
        {
            driver = WebDriverInstance.INSTANCE;
        }
        [Then(@"I check if the result eqauls '(.*)'")]
        public void ThenICheckIfTheResultEqauls(string expectedValue)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string actualValue = driver.FindElement(CalculatorPageModel.DisplaySelector).GetAttribute("value");
            Assert.AreEqual(expectedValue, actualValue);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
