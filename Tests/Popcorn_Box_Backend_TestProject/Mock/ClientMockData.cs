using Popcorn_Box_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn_Box_Backend_TestProject.Mock
{
    internal class ClientMockData
    {
        public static List<Media> GetMedia()
        {
            return new List<Media>
            {
                new Media {Id=1, Name="Rang De Basanti", Actors="Amir Khan,Madhawan,Sharman Joshi",Directors="Ashutosh Gowarikar", GenreId=3,Year=DateTime.Today, MediaId=2, ClientId=3, Thumbnail="...", Trailer="...", FullLength="..."},
                new Media {Id=2, Name="Tamasha", Actors="Ranbir Kapoor, Deepika Padukone",Directors="Imtiaz Ali", GenreId=5,Year=DateTime.Today, MediaId=2, ClientId=3, Thumbnail="...", Trailer="...", FullLength="..."},
                new Media {Id=3, Name="Delhi Crime", Actors="Shefali Shah",Directors="Tanuj Chopra", GenreId=1,Year=DateTime.Today, MediaId=1, ClientId=3, Thumbnail="...", Trailer="...", FullLength="..."}
            };
        }

        public static List<MediaType> GetMediaTypes()
        {
            return new List<MediaType>
            {
                new MediaType {MediaId=1, Name = "TvShows"},
                new MediaType {MediaId=2, Name = "Movies"}
            };
        }

        public static List<Genre> GetGenre()
        {
            return new List<Genre>
            {
                new Genre { GenreId = 1, Name = "Crime"},
                new Genre { GenreId = 2, Name = "Action"},
                new Genre { GenreId = 3, Name = "Triller"},
                new Genre { GenreId = 4, Name = "Horror"},
                new Genre { GenreId = 5, Name = "Romantic"},
                new Genre { GenreId = 6, Name = "Comedy"},
                new Genre { GenreId = 7, Name = "Science Fiction"},
                new Genre { GenreId = 8, Name = "Animation"},
                new Genre { GenreId = 9, Name = "Drama"},
                new Genre { GenreId = 10, Name = "Suspense"},
                new Genre { GenreId = 11, Name = "Rock"},
                new Genre { GenreId = 12, Name = "Hip Hop"},
                new Genre { GenreId = 13, Name = "Jazz"},
                new Genre { GenreId = 14, Name = "Edm"},
                new Genre { GenreId = 15, Name = "Sad"},
            };
        }

        public static List<Song> GetSongs()
        {
            return new List<Song>
            {
                new Song {SongsId=1,Name="Ghar se Nikaltei",Singers="Armaan Malik",Lyrics="Ghar Se Nikaltehi", Year=DateTime.Today,GenreId=10, ClientId=3,Thumbnail="...",SongUrl="...",Composer="Armaan Malik"},
                new Song {SongsId=2,Name="Bhula Diya",Singers="Darshan Rawal",Lyrics="Anurag Salakhiya", Year=DateTime.Today,GenreId=1, ClientId=3,Thumbnail="...",SongUrl="...",Composer="Armaan Malik"},
                new Song {SongsId=3,Name="Buzz",Singers="Aastha Gill, Baadshah",Lyrics="Ghar Se Nikaltehi", Year=DateTime.Today,GenreId=12, ClientId=3,Thumbnail="...",SongUrl="...",Composer="Armaan Malik"},
            };
        }
    }
}
