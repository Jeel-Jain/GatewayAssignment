using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagementProject.Controllers;

using ProductManagementProject;
using System.Web.Mvc;
using WebApi.Models;
using System.Linq;
using ProductManagementProject.Context;

namespace ProductManagementProjectTests
{
    [TestClass]
    public class ProductControllerTests
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

        [TestMethod]
        public void ProductLists()
        {
            ProductEntities1 dbObj2 = new ProductEntities1();

            //Arrange
            //  ProductController controller = new ProductController();

            //Act
            var result = dbObj2.tbl_product.ToList();

            //Assert
            Assert.IsNotNull(result);

        }
    }
}
