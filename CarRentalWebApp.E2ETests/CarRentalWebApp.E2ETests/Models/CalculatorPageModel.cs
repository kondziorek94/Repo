using OpenQA.Selenium;

namespace CarRentalWebApp.E2ETests.Models
{
    public class CalculatorPageModel : PageModel
    {

        public static By DisplaySelector = By.Id("calculatorDisplay");
        public static By EqualSignSelector = By.Id("equals2");
        public static By GetButtonLocator(string symbol)
        {
            switch (symbol)
            {
                case "CE":
                    return By.Id("clear");
                case "=":
                    return By.Id("equals2");
                default:
                    return By.Id(symbol);

            }
        }
    }
}
