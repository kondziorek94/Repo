using OpenQA.Selenium;

namespace CarRentalWebApp.E2ETests.Models
{
    public class HomePageModel : PageModel
    {
        public static By AboutSelector = By.LinkText("About");
        public static By ContactSelector = By.LinkText("Contact");
        public static By CalculatorSelector = By.LinkText("Go to calculator");
        public static By LogInSelector = By.LinkText("LogIn");
        public static By GoToTheListSelector = By.LinkText("Go to the list");
        public static By TitleSelector = By.TagName("h1");
    }
}
