using Popcorn_Box_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn_Box_Backend_TestProject.Mock
{
    public class FavouriteSongMockData
    {
        public static List<FavouriteSong> GetFavouriteSong()
        {
            return new List<FavouriteSong> 
            { 
                new FavouriteSong { UserId = 2, SongId = 1 },
            };
        }
    }
}
