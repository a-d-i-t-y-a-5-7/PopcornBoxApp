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

namespace Popcorn_Box_Backend_TestProject.Services
{
    public class TestFavouriteSongService : IDisposable
    {
        private readonly PopcornBoxDbContext context;
        public TestFavouriteSongService()
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

        public static IEnumerable<object[]> AddFavouriteSongData => new List<object[]>
        {
            new object [] { true , new FavouriteSong { UserId = 2, SongId = 2} },
            new object [] { false, new FavouriteSong { UserId = 2, SongId = 1} }
        };

        public static IEnumerable<object[]> RemoveFavouriteSongData => new List<object[]>
        {
            new object [] { false, new FavouriteSong { UserId = 2, SongId = 2} },
            new object [] { true , new FavouriteSong { UserId = 2, SongId = 1} }
        };

        [Theory]
        [MemberData(nameof(AddFavouriteSongData))]
        public bool AddFavouriteSong(bool expRes, FavouriteSong favouriteSong)
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteSong.AddRange(FavouriteSongMockData.GetFavouriteSong());
            context.SaveChanges();
            var sut = new FavouriteSongServices(context);

            //Act
            var result = sut.AddFavouriteSong(favouriteSong);

            //Assert
            Assert.Equal(expRes, result);
            return result;
        }

        [Theory]
        [MemberData(nameof(RemoveFavouriteSongData))]
        public bool RemoveFavouriteSong(bool expRes, FavouriteSong favouriteSong)
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteSong.AddRange(FavouriteSongMockData.GetFavouriteSong());
            context.SaveChanges();
            var sut = new FavouriteSongServices(context);

            //Act
            var result = sut.RemoveFavouriteSong(favouriteSong);

            //Assert
            Assert.Equal(expRes, result);
            return result;
        }

        [Fact]
        public List<Song> GetFavouriteSong()
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteSong.AddRange(FavouriteSongMockData.GetFavouriteSong());
            context.SaveChanges();
            var sut = new FavouriteSongServices(context);

            //Act
            var result = sut.GetFavouriteSong(2);

            //Assert
            result.Should().NotBeEmpty();
            return result;
        }

        [Fact]
        public List<Song> GetFavouriteSong_ShouldReturnEmpty()
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            context.FavoriteSong.AddRange(FavouriteSongMockData.GetFavouriteSong());
            context.SaveChanges();
            var sut = new FavouriteSongServices(context);

            //Act
            var result = sut.GetFavouriteSong(3);

            //Assert
            result.Should().BeEmpty();
            return result;
        }
    }
}
