using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public class FavouriteMediaServices : IFavouriteMediaServices
    {
        private readonly PopcornBoxDbContext _context;
        public FavouriteMediaServices(PopcornBoxDbContext _context)
        {
            this._context = _context;
        }
        public bool AddFavouriteMedia(FavouriteMedia fMedia)
        {
            var fav = from f in _context.FavoriteMedia where f.UserId == fMedia.UserId && f.MediaId == fMedia.MediaId select f;
            if (fav.Count()>0)
            {
                return false;
            }
            _context.FavoriteMedia.Add(fMedia);
            _context.SaveChanges();
            return true;
        }
        public bool RemoveFavouriteMedia(FavouriteMedia fMedia)
        {
            FavouriteMedia fav1 = _context.FavoriteMedia.FirstOrDefault(fm => fm.UserId== fMedia.UserId && fm.MediaId==fMedia.MediaId);
            if(fav1 != null) 
            {
                _context.FavoriteMedia.Remove(fav1);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Media> GetFavouriteMedia(int id)
        {
            var result = from media in _context.Medias
                         where (from favorite in _context.FavoriteMedia
                         where favorite.UserId == id
                         select favorite.MediaId)
                         .Contains(media.Id)
                         select media;
            return result.ToList();

        }
    }
}
