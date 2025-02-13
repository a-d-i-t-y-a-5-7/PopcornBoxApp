using System.ComponentModel.DataAnnotations;

namespace Popcorn_Box_Backend.Models
{
    public class Song
    {
        public int SongsId { get; set; }

        [Required]
        [MinLength(3), MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        [MinLength(5), MaxLength(40)]
        public string? Singers { get; set; }

        [Required]
        [MinLength(5), MaxLength(40)]
        public string? Composer { get; set; }

        [Required]
        [MinLength(5), MaxLength(500)]
        public string? Lyrics { get; set; }

        [Required]
        public DateTime? Year { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public string? Thumbnail { get; set; }

        [Required]
        public string? SongUrl { get; set; }

        public Genre? Genre { get; set; }
        public User? User { get; set; }
        public ICollection<FavouriteSong>? FavSongCollection { get; set; }
    }
}
