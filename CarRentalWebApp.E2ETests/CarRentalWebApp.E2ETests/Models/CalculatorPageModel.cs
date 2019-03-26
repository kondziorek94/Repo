using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWebApp.E2ETests.Models
{
    public class CalculatorPageModel
    {
        private IWebDriver driver = WebDriverInstance.INSTANCE;
        public static By DisplaySelector = By.Id("calculatorDisplay");
        public static By EqualSignSelector = By.Id("equals2");

        public void ClickButton(By selector)
        {
            IWebElement button = driver.FindElement(selector);
            button.Click();
        }
    }
}
