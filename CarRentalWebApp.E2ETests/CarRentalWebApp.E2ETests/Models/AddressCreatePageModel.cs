using OpenQA.Selenium;

namespace CarRentalWebApp.E2ETests.Models
{
    class AddressCreatePageModel : PageModel
    {
        public static By VipSelector = By.CssSelector("option[value='0']");
        public static By CriticalSelector = By.CssSelector("option[value='1']");
        public static By RegularSelector = By.CssSelector("option[value='2']");
        public static By CreateSelector = By.CssSelector("input[type='submit']");
    }
}