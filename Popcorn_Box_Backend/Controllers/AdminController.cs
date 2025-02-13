using Microsoft.AspNetCore.Mvc;
using Popcorn_Box_Backend.Identity;
using Popcorn_Box_Backend.Models;
using Popcorn_Box_Backend.Services;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminServices;
        public AdminController(IAdminService adminServices)
        {
            _adminServices = adminServices;
        }

        [HttpGet("getUser/{id}")]
        public IActionResult GetUserDetails(int id)
        {
            List<User> user = _adminServices.GetUserDetails(id);
            return Ok(user);
        }

        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_adminServices.DeleteUser(id))
            {
                return Ok("User Deleted");
            }
            else
            {
                return BadRequest("Enter correct user id");
            }
        }

        [HttpPost("clientId/{clientId}")]
        [RequiresClaim(Identities.role, Identities.admin)]
        public IActionResult ApproveClient(int clientId)
        {
            if (_adminServices.ApproveClient(clientId))
            {
                return Ok("Approval Granted");
            }
            else
            {
                return BadRequest("Enter correct user id");
            }
        }

        [HttpGet("/pedingAprovals")]
        [RequiresClaim(Identities.role, Identities.admin)]
        public IActionResult PendingApprovals()
        {
            List<User> pendingApp = _adminServices.PendingApprovals();
            return Ok(pendingApp);
        }
    }
}
