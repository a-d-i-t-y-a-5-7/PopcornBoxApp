using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public interface IFavouriteMediaServices
    {
        public bool AddFavouriteMedia(FavouriteMedia fMedia);
        public bool RemoveFavouriteMedia(FavouriteMedia fMedia);
        public List<Media> GetFavouriteMedia(int id);
    }
}
