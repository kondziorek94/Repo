using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalWebApp.Controllers;
namespace CarRentalWebApp.Tests.Controllers
{

    [TestClass]
    public class CalculatorControllerTest
    {
        [TestMethod]
        public void Index()
        {
            CalculatorController controller = new CalculatorController();

            ViewResult result = controller.Calculator() as ViewResult;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetSecuredData()
        {

            CalculatorController controller = new CalculatorController();

            var actualResult1 = controller.GetSecuredData("admin", "admin");
            var actualResult2 = controller.GetSecuredData("admin", "gestwina");
            var actualResult3 = controller.GetSecuredData("Kondzio", "admin");

            string expectedResult1 = "Hello admin, your secured information is .......";
            string expectedResult23 = "Wrong username or password, please retry.";

            Assert.AreEqual(expectedResult1, actualResult1);
            Assert.AreEqual(expectedResult23, actualResult2);
            Assert.AreEqual(expectedResult23, actualResult3);
        }
        [TestMethod]
        public void Evaluate()
        {
            CalculatorController controller = new CalculatorController();
            var actual = ((ViewResult)controller.Evaluate(5, 1, "+")).Model;
            var expected = "5 + 1 = 6";
            Assert.AreEqual(expected, actual);
        }
    }
}
