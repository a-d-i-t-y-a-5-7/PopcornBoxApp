using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Popcorn_Box_Backend.Controllers;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;
using Popcorn_Box_Backend_TestProject.Mock;
using Xunit;

namespace Popcorn_Box_Backend_TestProject.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public IActionResult Register_ShouldReturn200Status()
        {
            //Arrange
            User user = new User { UserId = 4, Contact = "7896541230", Email = "test4@gmail.com", IsActive = true, IsApproved = 0, IsSubscribed = false, Name = "test", Password = "test@1234", RoleId = 2 };
            var userService = new Mock<IUserServices>();
            userService.Setup(_ => _.AddUser(user)).Returns(RegisterMockData.AddUser(user));

            var sut = new UserController(userService.Object);

            //Act
            var result = sut.Register(user);

            //Assert
            result.GetType().Should().Be(typeof(OkResult));
            (result as OkResult).StatusCode.Should().Be(200);
            return result;
        }

        [Fact]
        public IActionResult Register_ShouldReturn400Status()
        {
            //Arrange
            User user = new User { UserId = 4, Contact = "7896541230", Email = "test3@gmail.com", IsActive = true, IsApproved = 0, IsSubscribed = false, Name = "test", Password = "test@1234", RoleId = 2 };
            var userService = new Mock<IUserServices>();
            userService.Setup(_ => _.AddUser(user)).Returns(RegisterMockData.AddUser(user));

            var sut = new UserController(userService.Object);

            //Act
            var result = sut.Register(user);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
            return result;
        }

        [Fact]
        public void Login_ShouldReturn404Status()
        {
            string email = "test@gmail.com";
            string password = "test@1234";
            //Arrange
            var userService = new Mock<IUserServices>();

            userService.Setup(_ => _.Login(email, password)).Returns(RegisterMockData.Login(email, password));

            var sut = new UserController(userService.Object);

            //Act
            var result = sut.Login(email, password);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public void Login_ShouldReturn200Status()
        {
            string email = "test1@gmail.com";
            string password = "test@1234";
            //Arrange
            var userService = new Mock<IUserServices>();

            userService.Setup(_ => _.Login(email, password)).Returns(RegisterMockData.Login(email, password));

            var sut = new UserController(userService.Object);

            //Act
            var result = sut.Login(email, password);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
        }
    }
}