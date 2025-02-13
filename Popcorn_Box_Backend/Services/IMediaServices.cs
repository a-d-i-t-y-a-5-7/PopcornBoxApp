using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public interface IMediaServices
    {
        IEnumerable<Media> GetMediaDetails();

        IEnumerable<Media> GetSpecificMediaDetails(int id);

        IEnumerable<Media> GetMediaGenreList(int mId, int gId);

        public Task<Media> GetMedia(int id);

        IEnumerable<Song> GetSongDetails();

        IEnumerable<Song> GetSongGenreList(int id);



    }
}
