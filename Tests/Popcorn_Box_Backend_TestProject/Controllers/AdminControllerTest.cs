using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Popcorn_Box_Backend.Controllers;
using Popcorn_Box_Backend.Services;
using Popcorn_Box_Backend_TestProject.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Popcorn_Box_Backend_TestProject.Controllers
{
    public class AdminControllerTest
    {
        [Fact]
        public void GetUserDetails_Returns200()
        {
            //Arrange
            var adminService = new Mock<IAdminService>();
            adminService.Setup(_ => _.GetUserDetails(1)).Returns(AdminMockData.GetUserDetails(1));
            var sut = new AdminController(adminService.Object);

            //Act
            var result = sut.GetUserDetails(1);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public void DeleteUser_Returns200()
        {
            //Arrange
            var adminService = new Mock<IAdminService>();
            adminService.Setup(_ => _.DeleteUser(1)).Returns(AdminMockData.DeleteUser(1));
            var sut = new AdminController(adminService.Object);

            //Act
            var result = sut.DeleteUser(1);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public void DeleteUser_Returns400()
        {
            //Arrange
            var adminService = new Mock<IAdminService>();
            adminService.Setup(_ => _.DeleteUser(4)).Returns(AdminMockData.DeleteUser(4));
            var sut = new AdminController(adminService.Object);

            //Act
            var result = sut.DeleteUser(4);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
        }

        [Fact]
        public void ApproveClient_ShouldReturn200()
        {
            //Arrange
            var adminService = new Mock<IAdminService>();
            adminService.Setup(_ => _.ApproveClient(3)).Returns(AdminMockData.ApproveClient(3));
            var sut = new AdminController(adminService.Object);

            //Act
            var result = sut.ApproveClient(3);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public void ApproveClient_ShouldReturn400()
        {
            //Arrange
            var adminService = new Mock<IAdminService>();
            adminService.Setup(_ => _.ApproveClient(4)).Returns(AdminMockData.ApproveClient(4));
            var sut = new AdminController(adminService.Object);

            //Act
            var result = sut.ApproveClient(4);

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
        }
    }
}
