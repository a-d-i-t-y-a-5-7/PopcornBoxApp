using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteMediaController : ControllerBase
    {
        private readonly IFavouriteMediaServices _favouriteMediaServices;

        public FavouriteMediaController(IFavouriteMediaServices favouriteMediaServices)
        {
            _favouriteMediaServices = favouriteMediaServices;
        }

        [HttpPost("/User/favouriteMedia/add")]
        [Authorize]
        public IActionResult AddFavouriteMedia(FavouriteMedia fMedia)
        {
            if (_favouriteMediaServices.AddFavouriteMedia(fMedia))
            {
                return Ok(new { response = true, Message="Favourite Added" });
            }
            else
            {
                return BadRequest(new { response = false, Message = "Already Exists" });
            }
        }
        [HttpPost("/User/favouriteMedia/remove")]
        [Authorize]
        public IActionResult RemoveFavouriteMedia(FavouriteMedia fMedia)
        {
            if (_favouriteMediaServices.RemoveFavouriteMedia(fMedia))
            {
                return Ok(new { response = true, Message = "Favourite removed" });
            }
            else
            {
                return BadRequest(new { response = false, Message = "Favourite does not exists" });
            }
        }
        [HttpGet("/User/favouriteMedia/myFavs/{id}")]
        [Authorize]
        public IActionResult GetMyFav(int id)
        {
            List<Media> myFav = _favouriteMediaServices.GetFavouriteMedia(id);
            return Ok(myFav);
        }
    }
}
