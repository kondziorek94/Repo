using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace CarRentalWebApp.E2ETests.Models
{
    public class WebDriverInstance
    {
        public static IWebDriver INSTANCE { private set; get; }
        public static void Reinstiate()
        {
            INSTANCE = new ChromeDriver();
        }

    }
}
