using OpenQA.Selenium;
namespace CarRentalWebApp.E2ETests.Models
{
    class NavbarModel
    {
        public static By LogInSelector = By.Id("loginLink");
        public static By LogOffSelector = By.LinkText("Log off");
    }
}
