using CarRentalWebApp.E2ETests.Models;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver driver ;

        [Before]
        public void BeforeScenario()
        {
            WebDriverInstance.Reinstiate();
            driver = WebDriverInstance.INSTANCE;
        }

        [After]
        public void AfterScenario()
        {
            driver.Dispose();
        }
    }
}
//1. ZROB KOPIE CALEGO PROJEKTU
//2. Oryginal sprobuj dodac do jakiegos repozytorium github, nie musi byc to samo co CarRentalWebApp
//3. Napisz test ktory idzie do strony Contact i sprawdza czy jest na tej stronie 
//4. NIE podejmuj sie 3. jezeli nie wykonasz 2.