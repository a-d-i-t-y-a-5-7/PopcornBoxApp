using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Popcorn_Box_Backend.Exceptions;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService _clientService, ILogger<ClientController> logger)
        {
            clientService = _clientService;
            _logger = logger;
        }
        
        [HttpGet("medialist/{id}")]
        public Task<IEnumerable<Media>> GetMedias(int id)
        {
            var mediaList = clientService.GetMediaList(id);
            if (mediaList == null)
            {
                throw new DirectoryNotFoundException($"Media type not available.");
            }
            return mediaList;
        }

        [HttpGet("getmediabyid/{id}")]
        public Task<Media> GetMedia(int id)
        {
            _logger.LogInformation($"Fetch Media with ID: {id} from the database");
            var media = clientService.GetMedia(id);
            try
            {
                if (media.Result == null)
                {
                    throw new NotFoundException($"Media ID {id} not found.");
                }
                _logger.LogInformation($"Returning Media with ID: {media.Result.Id}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return media;
        }

        [HttpPost("addmedia")]
        public Task<Media> PostMedia(Media media)
        {
            return clientService.AddMedia(media);
        }

        [HttpPut("updatemedia/{id}")]
        public Task<Media> PutMedia(Media media)
        {
            return clientService.UpdateMedia(media);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteMedia(int id)
        {
            return clientService.DeleteMedia(id);
        }

        [HttpGet("filtermedia")]
        public Task<List<Media>> FilterMedia(int Id)
        {
            throw new System.NotImplementedException("Not Implemented Exception!");
        }

        [HttpGet("songlist/{id}")]
        public Task<IEnumerable<Song>> GetSongs(int id)
        {
            var songList = clientService.GetSongList(id);
            if (songList == null)
            {
                throw new DirectoryNotFoundException($"Media type not available.");
            }
            return songList;
        }

        [HttpGet("getsongbyid/{id}")]
        public Task<Song> GetSong(int id)
        {
            _logger.LogInformation($"Fetch Song with ID: {id} from the database");
            var song = clientService.GetSong(id);
            try
            {
                if (song.Result == null)
                {
                    throw new NotFoundException($"Song ID {id} not found.");
                }
                _logger.LogInformation($"Returning Song with ID: {song.Result.SongsId}.");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return song;
        }

        [HttpPost("addsong")]
        public Task<Song> PostSong(Song song)
        {
            return clientService.AddSong(song);
        }

        [HttpPut("updatesong/{id}")]
        public Task<Song> PutSong(Song song)
        {
            return clientService.UpdateSong(song);
        }

        [HttpDelete("deletesong/{id}")]
        public Task<bool> DeleteSong(int id)
        {
            return clientService.DeleteSong(id);
        }
    }
}
