using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerService.API;
using TaskManagerService.API.Controllers;
using TaskManagerService.Entities;

namespace TaskManagerService.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
            IEnumerable<UserTask> result = controller.GetTaskDetails();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
            UserTask result = controller.GetTaskDetailsById(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
            controller.Post(new UserTask());

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
            controller.Delete(5);

            // Assert
        }
    }
}
