using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NuGet.Configuration;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;
using Popcorn_Box_Backend_TestProject.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Popcorn_Box_Backend_TestProject.Services
{
    public class TestUserService : IDisposable
    {
        private readonly PopcornBoxDbContext _context;
        private readonly IConfiguration _config;

        public TestUserService()
        {
            var options = new DbContextOptionsBuilder<PopcornBoxDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _context = new PopcornBoxDbContext(options);

            _context.Database.EnsureCreated();
        }

        TestUserService(IConfiguration config)
        {
            _config = config;
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        public static IEnumerable<object[]> UserData => new List<object[]>
        {
            new object [] { true, new User { UserId = 5, Contact = "7896541230", Email = "test5@gmail.com", IsActive = false, IsApproved = 0, IsSubscribed = false, Name = "test", Password = "test@1234", RoleId = 2 }},
            new object [] { false, new User { UserId = 6, Contact = "7896541230", Email = "test3@gmail.com", IsActive = false, IsApproved = 0, IsSubscribed = false, Name = "test", Password = "test@1234", RoleId = 2 }},
            new object []  {true, new User { UserId = 7, Contact = "7896541230", Email = "test4@gmail.com", IsActive = false, IsApproved = 0, IsSubscribed = false, Name = "test", Password = "test@1234", RoleId = 2 } }
        };

        [Theory]
        [MemberData(nameof(UserData))]
        public bool AddUser(bool expRes, User user)
        {
            //Arrange
            _context.Users.AddRange(RegisterMockData.GetUsers());
            _context.SaveChanges();
            var sut = new UserServices(_context,_config);

            //Act
            bool result = sut.AddUser(user);

           //Assert
           Assert.Equal(expRes, result);
           return result;
        }

        [Fact]
        public void Login()
        {
            //Arrange
            _context.Users.AddRange(RegisterMockData.GetUsers());
            _context.SaveChanges();
            var sut = new UserServices(_context, _config);

            //Act
            string email = "te@gmail.com";
            string password = "test@1234";
            string result = sut.Login(email,password);

            //Assert
            result.Should().Be("User not found");
        }

        [Fact]
        public void Login_ShouldReturnTryAfterSometime()
        {
            //Arrange
            _context.Users.AddRange(RegisterMockData.GetUsers());
            _context.SaveChanges();
            var sut = new UserServices(_context, _config);

            //Act
            string email = "testClient@gmail.com";
            string password = "test@1234";
            string result = sut.Login(email, password);

            //Assert
            result.Should().Be("Please try after sometime your Account is not approved yet");
        }
    }
}
