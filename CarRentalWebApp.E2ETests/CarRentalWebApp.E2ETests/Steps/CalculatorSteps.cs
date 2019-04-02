using CarRentalWebApp.E2ETests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
        [Then(@"I check if the result equals to '(.*)'")]
        [Given(@"I check if the result equals to '(.*)'")]
        public void ThenICheckIfTheResultEqualsTo(string expectedValue)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string actualValue = driver.FindElement(CalculatorPageModel.DisplaySelector).GetAttribute("value");
            Assert.AreEqual(expectedValue, actualValue);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Given(@"I click ""(.*)"" calculator buttons")]
        public void GivenIClickCalculatorButtons(string buttons)
        {
            string[] buttonList = buttons.Contains(",") ? buttons.Split(',') : new string[] { buttons };
            foreach (string character in buttonList)
            {
                PageModel.ClickButton(CalculatorPageModel.GetButtonLocator(character));
            }


        }




    }
}
