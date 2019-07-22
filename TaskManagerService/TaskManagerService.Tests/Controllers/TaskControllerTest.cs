using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerService.API;
using TaskManagerService.API.Controllers;
using TaskManagerService.BusinessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.Tests.Controllers
{
    [TestClass]
    public class TaskControllerTest
    {
        private void MockHttpContext()
        {
            HttpContext.Current = new HttpContext(new HttpRequest(string.Empty, "http://tempuri.org", string.Empty),
                                                  new HttpResponse(new StringWriter(CultureInfo.InvariantCulture)));
           
        }
        [TestMethod]
        public void Get()
        {
            // Arrange
            TaskManagerOperations controller = new TaskManagerOperations();
           
                // Act
                var result = controller.GetTaskDetails();

             
            Assert.IsNotNull(result.Count());
            Assert.Equals(2, result.Count());


        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
           // UserTask result = controller.GetTaskDetailsById(5);

            // Assert
          //  Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
         //   controller.Post(new UserTask());

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
           // controller.Delete(5);

            // Assert
        }
    }
}
