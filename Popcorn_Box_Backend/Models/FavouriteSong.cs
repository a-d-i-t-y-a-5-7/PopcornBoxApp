namespace Popcorn_Box_Backend.Models
{
    public class FavouriteSong
    {
        public int FavSongId { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public User? user { get; set; }
        public Song? song { get; set; }
    }
}
