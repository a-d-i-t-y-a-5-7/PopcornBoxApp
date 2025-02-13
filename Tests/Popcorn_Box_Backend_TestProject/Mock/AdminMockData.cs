using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn_Box_Backend_TestProject.Mock
{
    public class AdminMockData
    {
        public static List<User> GetUserDetails(int id)
        {
            List<User> Users = new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=1},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=3},

            };
            var userResult = from u in Users where u.IsActive && u.RoleId == id select u;
            return userResult.ToList<User>();
        }

        public static bool DeleteUser(int id)
        {
            List<User> Users = new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=1},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=3},

            };

            for(int i=0; i < Users.Count; i++)
            {
                if (Users[i].UserId == id)
                {
                    Users[i].IsActive = false;
                    return true;
                }
            }
            return false;
        }

        public static bool ApproveClient(int id)
        {
            List<User> Users = new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=1},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=3},

            };
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserId == id && Users[i].RoleId == 3)
                {
                    Users[i].IsApproved = 1;
                    return true;
                }
            }
            return false;
        }

        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=1},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=3},
            };
        }

        public static List<User> GetPendingApproval()
        {
            var pendingApprovals = from u in GetUsers() where u.RoleId==3 && u.IsApproved==0 select u;

            return pendingApprovals.ToList<User>();
        }
    }
}
