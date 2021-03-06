﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRentalWebApp.Controllers;
namespace CarRentalWebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            var actual = result.ViewBag.Message;
            var expected = "Your application description page!";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}