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
    public class TestClientService : IDisposable
    {
        private readonly PopcornBoxDbContext context;

        public TestClientService()
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

        public static IEnumerable<object[]> SongData => new List<object[]>
        {
            new object[]{ new Song { SongsId = 1, Name = "Ghar se Nikaltei", Singers = "Armaan Malik", Lyrics = "Ghar Se Nikaltehi", Year = DateTime.Today, GenreId = 10, ClientId = 3, Thumbnail = "...", SongUrl = "...", Composer = "Armaan Malik" }, 1}
        };

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 5)]
        public void DeleteMedia(bool expRes,int id)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new ClientService(context);

            //Act
            var result = sut.DeleteMedia(id);

            //Assert
            Assert.Equal(expRes, result.Result);
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 5)]
        public void DeleteSong(bool expRes,int id)
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new ClientService(context);

            //Act
            var result = sut.DeleteSong(id);

            //Assert
            Assert.Equal(expRes, result.Result);
        }

        [Theory]
        [InlineData(null, 100)]
        [MemberData(nameof(MediaData))]
        public void GetMedia(Media med, int id)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new ClientService(context);
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

        [Theory]
        [InlineData(0, 100)]
        [InlineData(3, 3)]
        public void GetMediaList(int count, int id)
        {
            context.Medias.AddRange(ClientMockData.GetMedia());
            context.SaveChanges();
            context.MediaTypes.AddRange(ClientMockData.GetMediaTypes());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new ClientService(context);

            //Act
            var result = sut.GetMediaList(id);

            //Assert
            Assert.Equal(count, result.Result.Count());
        }

        [Theory]
        [InlineData(null, 100)]
        [MemberData(nameof(SongData))]
        public void GetSong(Song songExp, int id)
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new ClientService(context);
            //Act
            var result = sut.GetSong(id);

            //Assert
            if (songExp != null)
            {
                Assert.Equal(songExp.SongsId, result.Result.SongsId);
            }
            if (songExp == null)
            {
                Assert.Equal(songExp, result.Result);
            }
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(3, 3)]
        public void GetSongList(int count, int id)
        {
            context.Songs.AddRange(ClientMockData.GetSongs());
            context.SaveChanges();
            context.Genres.AddRange(ClientMockData.GetGenre());
            context.SaveChanges();
            context.Users.AddRange(AdminMockData.GetUsers());
            context.SaveChanges();
            var sut = new ClientService(context);

            //Act
            var result = sut.GetSongList(id);

            //Assert
            Assert.Equal(count, result.Result.Count());
        }
    }
}
