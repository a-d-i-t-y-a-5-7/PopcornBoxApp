using Popcorn_Box_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn_Box_Backend_TestProject.Mock
{
    internal class FavouriteMediaMockData
    {
        public static List<FavouriteMedia> GetFavouriteMedia()
        {
            return new List<FavouriteMedia>
            {
                new FavouriteMedia {MediaId=1, UserId=2}
            };
        }
    }
}
