using System.ComponentModel.DataAnnotations;

namespace Popcorn_Box_Backend.Models
{
    public class Media
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        [MinLength(5), MaxLength(40)]
        public string? Actors { get; set; }

        [Required]
        [MinLength(5), MaxLength(40)]
        public string? Directors { get; set; }

        [Required]
        
        public int GenreId { get; set; }

        [Required]
        public DateTime? Year { get; set; }

        [Required]
        public int MediaId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public string? Thumbnail { get; set; }

        [Required]
        public string? Trailer { get; set; }

        [Required]
        public string? FullLength { get; set; }
        

        public Genre? Genre { get; set; }
        public MediaType? MediaType { get; set; }
        public User? User { get; set; }
        public ICollection<FavouriteMedia>? FavouriteMediaCollection { get; set; }
    }
}
