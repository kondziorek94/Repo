using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalWebApp.Controllers;
using System.Collections.Generic;
using CarRentalWebApp.Models;
namespace CarRentalWebApp.Tests.Controllers
{
    [TestClass]
    public class AddressControllerTest
    {

        [TestMethod]
        public void Index()
        {
            AddressController controller = new AddressController();
            var numbers = new List<int>() { 2, 3, 5, 7 };
            ViewResult result = controller.Index("", "CityName_Asc", 1, 2) as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetNumberPages()
        {
            AddressController controller = new AddressController();
            var addresses = new List<Address>() { };
            for (int i = 0; i < 100; i++)
            {
                addresses.Add(null);
            }
            int result = controller.GetNumberPages(addresses);
            int expected = 50;
            Assert.AreEqual(expected, result);
        }
    }
}