using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public class FavouriteSongServices : IFavouriteSongServices
    {
        private readonly PopcornBoxDbContext _context;
        public FavouriteSongServices(PopcornBoxDbContext context)
        {
            _context = context;
        }
        public bool AddFavouriteSong(FavouriteSong favSong)
        {
            var fav = from f in _context.FavoriteSong where f.UserId == favSong.UserId && f.SongId == favSong.SongId select f;
            if(fav.Count() > 0)
            {
                return false;
            }
            _context.FavoriteSong.Add(favSong);
            _context.SaveChanges();
            return true;
        }

        public List<Song> GetFavouriteSong(int id)
        {
            var result = from song in _context.Songs
                         where (from favorite in _context.FavoriteSong
                                where favorite.UserId == id
                                select favorite.SongId)
                         .Contains(song.SongsId)
                         select song;
            return result.ToList();
        }

        public bool RemoveFavouriteSong(FavouriteSong favSong)
        {
            FavouriteSong fav = _context.FavoriteSong.FirstOrDefault(fs => fs.UserId == favSong.UserId && fs.SongId==favSong.SongId);
            if (fav != null)
            {
                _context.FavoriteSong.Remove(fav);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
