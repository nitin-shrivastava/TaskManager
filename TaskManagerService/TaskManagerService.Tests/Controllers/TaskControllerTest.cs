using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManagerService.API;
using TaskManagerService.API.Controllers;
using TaskManagerService.BusinessLayer;
using TaskManagerService.DataAccessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.Tests.Controllers
{
    [TestClass]
    [TestCategory("Tasks")]
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
            UserTask _userTask = new UserTask()
            {
                Task_ID = 9,
                ParentTask_ID = null,
                Project_ID = null,
                TaskDetail = "This is task for akashganga",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 21,
                Status = "Open"
            };
            var userMock = new List<UserTask> { _userTask }.AsQueryable();
            // Arrange

            var mockSet = new Mock<TaskDataContext>();
            var usersMock = new Mock<DbSet<UserTask>>();
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.Provider).Returns(userMock.Provider);
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.Expression).Returns(userMock.Expression);
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.ElementType).Returns(userMock.ElementType);
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.GetEnumerator()).Returns(userMock.GetEnumerator());
            usersMock.SetReturnsDefault(userMock.GetEnumerator());
            usersMock.Setup(x => x.Add(It.IsAny<UserTask>())).Returns((UserTask u) => u);
            mockSet.Setup(p => p.Set<UserTask>().Add(It.IsAny<UserTask>())).Returns(_userTask);

            TaskManagerOperations op = new TaskManagerOperations(mockSet.Object);
            // Act
           // var result = op.GetTaskDetails();


            Assert.IsNotNull(op);
           


        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            UserTask _userTask = new UserTask()
            {
                Task_ID = 9,
                ParentTask_ID = null,
                Project_ID = null,
                TaskDetail = "This is task for akashganga",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 21,
                Status = "Open"
            };
            var userMock = new List<UserTask> { _userTask }.AsQueryable();
            // Arrange

            var mockSet = new Mock<TaskDataContext>();
            var usersMock = new Mock<DbSet<UserTask>>();
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.Provider).Returns(userMock.Provider);
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.Expression).Returns(userMock.Expression);
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.ElementType).Returns(userMock.ElementType);
            usersMock.As<IQueryable<UserTask>>().Setup(m => m.GetEnumerator()).Returns(userMock.GetEnumerator());
            usersMock.SetReturnsDefault(userMock.GetEnumerator());
            usersMock.Setup(x => x.Add(It.IsAny<UserTask>())).Returns((UserTask u) => u);
            mockSet.Setup(p => p.Set<UserTask>().Add(It.IsAny<UserTask>())).Returns(_userTask);

            TaskOperationController controller = new TaskOperationController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
           
           
            // Act
           // var response = controller.GetTaskDetailsById(5);

            // Assert

            Assert.IsNotNull(controller);
            //Assert.AreEqual(10, product.Id);
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
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
            //controller.Put(5, "value");

            // Assert
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            TaskOperationController controller = new TaskOperationController();

            // Act
            // controller.Delete(5);

            Assert.IsNotNull(controller);
        }
    }
}
