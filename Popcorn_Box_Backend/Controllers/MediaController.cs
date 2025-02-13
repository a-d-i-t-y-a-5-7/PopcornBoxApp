using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Popcorn_Box_Backend.Exceptions;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaServices _mediaServices;
        public MediaController(IMediaServices mediaServices)
        {
            _mediaServices = mediaServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Media>>> GetMediaDetails()
        {
            List<Media> list = new List<Media>();
            list = (List<Media>)_mediaServices.GetMediaDetails();
            return Ok(list);
        }

        [HttpGet("mediaType/{id}")]
        public async Task<ActionResult<IEnumerable<Media>>> GetSpecificMediaDetails(int id)
        {
            var media = _mediaServices.GetSpecificMediaDetails(id);
            if (media == null)
            {
                throw new DirectoryNotFoundException($"Media type not available.");
            }
            return Ok(media);
        }

        [HttpGet("filterByMediaGenre/{id}")]
        public async Task<ActionResult<IEnumerable<Media>>> GetMediaGenreList(int mId,int gId)
        {
            var genreMedia = _mediaServices.GetMediaGenreList(mId, gId);
            if (genreMedia == null)
            {
                throw new DirectoryNotFoundException($"Media genre not available.");
            }
            return Ok(genreMedia);
        }

        [HttpGet("{id}")]
        public Task<Media> GetMedia(int id)
        {
            
            var media = _mediaServices.GetMedia(id);
            if (media.Result == null)
            {
                throw new NotFoundException($"Media ID {id} not found.");
            }
            
            return media;
        }

        [HttpGet("songs")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongDetails()
        {
            List<Song> list = new List<Song>();
            list = (List<Song>)_mediaServices.GetSongDetails();
            return Ok(list);
        }

        [HttpGet("filterBySongGenre/{id}")]
        public async Task<ActionResult<IEnumerable<Media>>> GetSongGenreList(int id)
        {
            var genreSong = _mediaServices.GetSongGenreList(id);
            if (genreSong == null)
            {
                throw new DirectoryNotFoundException($"Media genre not available.");
            }
            return Ok(genreSong);
        }
    }
}
