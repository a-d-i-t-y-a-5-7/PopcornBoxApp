using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Popcorn_Box_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public VideosController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine("E:\\Major_project\\Popcorn_Box_Frontend\\src\\assets\\", "videos");
                string uniqueFileName = Path.Combine(uploadsFolder, file.FileName);
                using (FileStream fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return Ok(file.FileName.ToJson() );

            }
            return BadRequest();
        }
        [HttpPost("uploadimage")]
        public IActionResult ImageUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine("E:\\Major_project\\Popcorn_Box_Frontend\\src\\assets\\", "images");
                string uniqueFileName = Path.Combine(uploadsFolder, file.FileName);
                using (FileStream fileStream = new FileStream(uniqueFileName, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return Ok(file.FileName.ToJson());

            }
            return BadRequest();
        }
    }
}
