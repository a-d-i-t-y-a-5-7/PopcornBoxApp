using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;
using Popcorn_Box_Backend_TestProject.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;

namespace Popcorn_Box_Backend_TestProject.Services
{
    public class TestFavouriteMediaService : IDisposable
    {
        private readonly PopcornBoxDbContext context;

        public TestFavouriteMediaService()
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

        public static IEnumerable<object[]> AddFavouriteMediaData => new List<object[]>
        {
            new object [] { true , new FavouriteMedia { UserId=2, MediaId=2} },
            new object [] { false, new FavouriteMedia { MediaId = 1, UserId = 2} }
        };

        public static IEnumerable<object[]> RemoveFavouriteMediaData => new List<object[]>
        {
            new object [] { false , new FavouriteMedia { UserId=2, MediaId=2} },
            new object [] { true , new FavouriteMedia { MediaId = 1, UserId = 2} }
        };

        [Theory]
        [MemberData(nameof(AddFavouriteMediaData))]
        public bool AddFavouriteMedia(bool expRes, FavouriteMedia fMedia)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteMedia.AddRange(FavouriteMediaMockData.GetFavouriteMedia());
            context.SaveChanges();
            var sut = new FavouriteMediaServices(context);

            //Act
            var result = sut.AddFavouriteMedia(fMedia);

            //Assert
            Assert.Equal(expRes, result);
            return result;
        }

        [Theory]
        [MemberData(nameof(RemoveFavouriteMediaData))]
        public bool RemoveFavouriteMedia(bool expRes, FavouriteMedia fMedia)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteMedia.AddRange(FavouriteMediaMockData.GetFavouriteMedia());
            context.SaveChanges();
            var sut = new FavouriteMediaServices(context);

            //Act
            var result = sut.RemoveFavouriteMedia(fMedia);

            //Assert
            Assert.Equal(expRes, result);
            return result;
        }

        [Fact]
        public List<Media> GetFavouriteMedia() 
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteMedia.AddRange(FavouriteMediaMockData.GetFavouriteMedia());
            context.SaveChanges();
            var sut = new FavouriteMediaServices(context);

            //Act
            var result = sut.GetFavouriteMedia(2);

            //Assert
            result.Should().NotBeNull();
            return result;
        }

        [Fact]
        public List<Media> GetFavouriteMedia_ShouldReturnNull()
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteMedia.AddRange(FavouriteMediaMockData.GetFavouriteMedia());
            context.SaveChanges();
            var sut = new FavouriteMediaServices(context);

            //Act
            var result = sut.GetFavouriteMedia(3);

            //Assert
            result.Should().BeEmpty();
            return result;
        }
    }
}
