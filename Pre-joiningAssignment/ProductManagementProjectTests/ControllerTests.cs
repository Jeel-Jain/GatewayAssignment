using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagementProject.Controllers;
using ProductManagementProject;
using System.Web.Mvc;

namespace ProductManagementProjectTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void Index()
        {

            //Arrange
            UserController controller = new UserController();

            //Act

            ViewResult result = controller.User() as ViewResult;

            //Assert

            Assert.IsNotNull(result);
        }
    }
}
