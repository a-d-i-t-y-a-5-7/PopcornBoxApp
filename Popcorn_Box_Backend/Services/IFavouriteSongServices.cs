using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public interface IFavouriteSongServices
    {
        public bool AddFavouriteSong(FavouriteSong favSong);
        public bool RemoveFavouriteSong(FavouriteSong favSong);
        public List<Song> GetFavouriteSong(int id);
    }
}
