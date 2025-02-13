using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public class ClientService : IClientService
    {
        private readonly PopcornBoxDbContext _dbContext;
        public ClientService(PopcornBoxDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Media> AddMedia(Media media)
        {
            var result = _dbContext.Medias.Add(media);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteMedia(int id)
        {
            var filteredData = _dbContext.Medias.Where(x => x.Id == id).FirstOrDefault();
            if(filteredData == null)
            {
                return false;
            }
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<bool> DeleteSong(int id)
        {
            var filteredData = _dbContext.Songs.Where(x => x.SongsId == id).FirstOrDefault();
            if (filteredData == null)
            {
                return false;
            }
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }

        public async Task<Media> GetMedia(int id)
        {
            return await _dbContext.Medias.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Media>> GetMediaList(int id)
        {
            if (_dbContext.Medias == null)
            {
                return null;
            }
            return await _dbContext.Medias.Where(x => x.ClientId == id).ToListAsync();
        }

        public async Task<Song> GetSong(int id)
        {
            return await _dbContext.Songs.Where(x => x.SongsId == id).FirstOrDefaultAsync();
        }

        public async Task<Song> AddSong(Song song)
        {
            var result = _dbContext.Songs.Add(song);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Song>> GetSongList(int id)
        {
            if (_dbContext.Songs == null)
            {
                return null;
            }
            return await _dbContext.Songs.Where(x => x.ClientId == id).ToListAsync();
        }

        public async Task<Media> UpdateMedia(Media media)
        {

            var result = _dbContext.Medias.Update(media);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Song> UpdateSong(Song song)
        {
            var result = _dbContext.Songs.Update(song);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
