using System.ComponentModel.DataAnnotations;

namespace Popcorn_Box_Backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [MinLength(3),MaxLength(40)]
        public string? Name { get; set; }
        [Required]
        [MinLength(10), MaxLength(10)]
        public string? Contact { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [MinLength(8),MaxLength(20)]
        public string? Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsSubscribed { get; set;}
        public int IsApproved { get; set; }
        public Role? Role { get; set; }
        public ICollection<Media>? MediasCollection { get; set; }
        public ICollection<Song>? SongsCollection { get; set; }
        public ICollection<FavouriteMedia>? FavouriteMediaCollection { get; set; } 
        public ICollection<FavouriteSong>? FavSongsCollection { get; set; }

    }
}
