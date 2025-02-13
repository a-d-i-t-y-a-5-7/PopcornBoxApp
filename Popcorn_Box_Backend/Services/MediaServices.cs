using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public class MediaServices:IMediaServices
    {
        private readonly PopcornBoxDbContext _context;
        public MediaServices(PopcornBoxDbContext context)
        {
            _context = context;
        }

        public async Task<Media> GetMedia(int id)
        {
            return await _context.Medias.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public IEnumerable<Media> GetMediaDetails()
        {
            if (_context.Medias == null) 
            {
                return null;
            }
            return _context.Medias.ToList();
        }

        public IEnumerable<Media> GetSpecificMediaDetails(int id)
        {
            if (_context.Medias == null)
            {
                return null;
            }
            return _context.Medias.Where(x => x.MediaId == id).ToList();
        }

        public IEnumerable<Media> GetMediaGenreList(int mId,int gId)
        {
            if (_context.Medias == null)
            {
                return null;
            }
            return _context.Medias.Where(x => x.MediaId == mId && x.GenreId == gId).ToList();
        }

        public IEnumerable<Song> GetSongDetails()
        {
            if (_context.Songs == null)
            {
                return null;
            }
            return _context.Songs.ToList();
        }

        public IEnumerable<Song> GetSongGenreList(int id)
        {
            if (_context.Songs == null)
            {
                return null;
            }
            return _context.Songs.Where(x => x.GenreId == id).ToList();
        }

    }
}
