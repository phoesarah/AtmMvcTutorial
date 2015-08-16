using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.Controllers;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //public void AboutActionReturnsAboutView()
        //{
        //    var homeController = new HomeController();
        //    var result = homeController.About() as ViewResult;
        //    Assert.AreEqual("About", result.ViewName);

        //}   Thsi does not work beacuse "About" is not passed explictely to the View()

        [TestMethod]
        public void ContactFormSaysThanks()
        {
            var homeController = new HomeController();
            var result = homeController.Contact("I love your bank.") as ViewResult;
            Assert.AreEqual("Ywe got your message.", result.ViewBag.Message);

        }
    }
}
