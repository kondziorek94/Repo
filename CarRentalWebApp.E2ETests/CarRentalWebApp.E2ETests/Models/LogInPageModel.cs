using OpenQA.Selenium;

namespace CarRentalWebApp.E2ETests.Models
{
    public class LogInPageModel : PageModel
    {
        public static By LogInButtonSelector = By.CssSelector("input[type='submit']");
    }
}