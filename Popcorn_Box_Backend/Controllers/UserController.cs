using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_userService.AddUser(user))
            {
                return Ok();
            }
            return Ok("Email Already Exists".ToJson());
        }
        [HttpPost("/login/{email},{password}")]
        public IActionResult Login(string email, string password)
        {
            string token = _userService.Login(email, password);
            if (token.Equals("User not found"))
            {
                return Ok(token.ToJson());
            }
            if(token.Equals("Please try after sometime your Account is not approved yet"))
            {
                return Ok(token.ToJson());
            }  
            return Ok(token.ToJson());

        }

        [HttpPatch("/user/{id}")]
        [Authorize]
        public IActionResult UpdateUser(int id, User user)
        {
            if (_userService.UpdateUser(id, user))
            {
                return Ok(new { response = true, Message = "Updated Successfuly" });
            }
            else
            {
                return Ok(new { response = false, Message = "Update operation failed" });
            }
        }
        [HttpGet("/get/user/{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }
    }
}