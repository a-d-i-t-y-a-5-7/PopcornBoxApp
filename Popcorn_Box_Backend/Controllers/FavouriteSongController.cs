using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteSongController : ControllerBase
    {
        private readonly IFavouriteSongServices _fav;

        public FavouriteSongController(IFavouriteSongServices fav)
        {
            _fav = fav;
        }

        [HttpPost("/user/favourite/song")]
        [Authorize]
        public IActionResult AddFavouriteSong(FavouriteSong favSong)
        {
            if (_fav.AddFavouriteSong(favSong))
            {
                return Ok(new { response = true, Message = "Favourite Song Added" });
            }
            else
            {
                return BadRequest(new { response = true, Message = "Already Song Exists"} );
            }
        }

        [HttpPost("/user/favouriteSong/remove")]
        [Authorize]
        public IActionResult RemoveFavouriteSong(FavouriteSong favSong)
        {
            if (_fav.RemoveFavouriteSong(favSong))
            {
                return Ok(new { response = true, Message = "Favourite Song Removed " });
            }
            else
            {
                return BadRequest(new { response = true, Message = "Favourite song does not exist" });
            }
        }
        [HttpGet("/user/favouriteSong/myFavSong/{id}")]
        [Authorize]
        public IActionResult GetMyFavouriteSong(int id)
        {
            List<Song> myFavSong = _fav.GetFavouriteSong(id);
            return Ok(myFavSong);
        }
    }
}
