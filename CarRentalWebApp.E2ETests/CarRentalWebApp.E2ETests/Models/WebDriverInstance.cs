using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace CarRentalWebApp.E2ETests.Models
{
    public class WebDriverInstance
    {
        public static readonly IWebDriver INSTANCE = new ChromeDriver();
    }
}
