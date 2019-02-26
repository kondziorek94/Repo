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
            // Arrange
            // Act
            ViewResult result = ((HomeController)new HomeController()).GetAbout() as ViewResult;
            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.GetContact() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}