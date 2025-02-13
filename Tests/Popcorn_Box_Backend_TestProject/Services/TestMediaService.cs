using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;
using Popcorn_Box_Backend_TestProject.Mock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Popcorn_Box_Backend_TestProject.Services
{
    public class TestMediaService : IDisposable
    {
        private readonly PopcornBoxDbContext context;

        public TestMediaService()
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

        public static IEnumerable<object[]> MediaData => new List<object[]>
        {
            new object [] { new Media{ Id = 1, Name = "Rang De Basanti", Actors = "Amir Khan,Madhawan,Sharman Joshi", Directors = "Ashutosh Gowarikar", GenreId = 3, Year = DateTime.Today, MediaId = 2, ClientId = 3, Thumbnail = "...", Trailer = "...", FullLength = "..." }, 1}
        };

        [Theory]
        [InlineData(null,100)]
        [MemberData(nameof(MediaData))]
        public void GetMedia(Media med,int id)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new MediaServices(context);

            //Act
            var result = sut.GetMedia(id);

            //Assert
            if (med != null)
            {
                Assert.Equal(med.Id, result.Result.Id);
            }
            if (med == null)
            {
                Assert.Equal(med, result.Result);
            }
        }

        [Fact]
        public void GetMediaDetails()
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new MediaServices(context);

            //Act
            var result = sut.GetMediaDetails();

            //Assert
            result.Should().HaveCount(ClientMockData.GetMedia().Count);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(0, 4)]
        public void GetSpecificMediaDetails(int count, int id)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new MediaServices(context);

            //Act
            var result = sut.GetSpecificMediaDetails(id);

            //Assert
            Assert.Equal(count, result.Count());
        }

        [Fact]
        public IEnumerable<Song> GetSongDetails()
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new MediaServices(context);

            //Act
            var result = sut.GetSongDetails();

            //Assert
            result.Should().HaveCount(ClientMockData.GetSongs().Count);
            return result;
        }
    }
}
