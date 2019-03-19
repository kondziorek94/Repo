using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWebApp.E2ETests.Models
{
    public class HomePageModel
    {
        private IWebDriver driver = WebDriverInstance.INSTANCE;

        public static By AboutSelector = By.LinkText("About");
        public static By ContactSelector = By.LinkText("Contact");
        public static By TitleSelector = By.TagName("h1");

        public void ClickButton(By selector)
        {
            IWebElement button = driver.FindElement(selector);
            button.Click();
        }


    }
}
