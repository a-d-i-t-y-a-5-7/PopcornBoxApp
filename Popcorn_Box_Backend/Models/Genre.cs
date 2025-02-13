using Microsoft.Build.Framework;

namespace Popcorn_Box_Backend.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Required] 
        public string? Name { get; set; }

        public ICollection<Media>? MediasCollection { get; set; }
        public ICollection<Song>? SongsCollection { get; set; }

    }
}
