using FluentAssertions;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
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
    public class TestAdminService : IDisposable
    {
        private readonly PopcornBoxDbContext context;

        public TestAdminService()
        {
            var options = new DbContextOptionsBuilder<PopcornBoxDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new PopcornBoxDbContext(options);
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(0, 4)]
        public void GetUserDetails(int count, int id)
        {
            //Arrange
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new AdminService(context);

            //Act
            var result = sut.GetUserDetails(id);
            count = AdminMockData.GetUserDetails(id).Count;
            //Assert
            Assert.Equal(count,result.Count);
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 4)]
        public void DeleteUser(bool res,int id)
        {
            //Arrange
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new AdminService(context);

            //Act
            var result = sut.DeleteUser(id);

            //Assert
            Assert.Equal(res, result);
        }

        [Theory]
        [InlineData(true, 3)]
        [InlineData(false, 2)]
        [InlineData(false, 4)]
        public void ApproveClient(bool expRes,int id)
        {
            //Arrange
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new AdminService(context);

            //Act
            var result = sut.ApproveClient(id);

            //Assert
            Assert.Equal(expRes, result);
        }

        [Fact]
        public void PendingApprovals()
        {
            //Arrange
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new AdminService(context);

            //Act
            var result = sut.PendingApprovals();
            var pendingCount = AdminMockData.GetPendingApproval().Count;
            //Assert
            Assert.Equal(pendingCount, result.Count);
        }
    }
}
