using System.ComponentModel.DataAnnotations.Schema;

namespace Popcorn_Box_Backend.Models
{
    public class FavouriteMedia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavId { get; set; }
        public int? UserId { get; set; }
        public int MediaId { get; set; }
        public User? user { get; set; }
        public Media? media { get; set; }
    }
}
