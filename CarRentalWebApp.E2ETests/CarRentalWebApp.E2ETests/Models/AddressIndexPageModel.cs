using OpenQA.Selenium;
namespace CarRentalWebApp.E2ETests.Models
{
    class AddressIndexPageModel:PageModel
    {
        public static By CreateNewSelector = By.LinkText("Create New");
        public static By SearchSelector = By.Id("search");
        public static By DeleteSelector = By.LinkText("Delete");
    }
}
