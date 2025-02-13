using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<Media>> GetMediaList(int id);
        public Task<Media> GetMedia(int id);
        public Task<Media> AddMedia(Media media);
        public Task<Media> UpdateMedia(Media media);
        public Task<bool> DeleteMedia(int id);

        public Task<IEnumerable<Song>> GetSongList(int id);
        public Task<Song> GetSong(int id);
        public Task<Song> AddSong(Song song);
        public Task<Song> UpdateSong(Song song);
        public Task<bool> DeleteSong(int id);
    }
}
