using Microsoft.Build.Framework;

namespace Popcorn_Box_Backend.Models
{
    public class MediaType
    {
        public int MediaId { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Media>? MediasCollection { get; set; }
    }
}
