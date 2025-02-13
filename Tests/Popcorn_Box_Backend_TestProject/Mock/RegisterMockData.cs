using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend_TestProject.Mock
{
    internal class RegisterMockData
    {
        public static bool AddUser(User user)
        {
            List<User> Users = new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

            };
            for(int i=0;i<Users.Count;i++)
            {
                if (Users[i].Email.Equals(user.Email))
                {
                    return false;
                }
            }
            Users.Add(user);
            return true;
        }

        public static string Login(string email, string password)
        {
            List<User> Users = new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

            };
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Email.Equals(email) && Users[i].Password.Equals(password))
                {
                    return "User found";
                }
            }
            return "User not found";
        }

        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User{UserId = 1, Contact="7896541230", Email="test1@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 2, Contact="7896541230", Email="test2@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 3, Contact="7896541230", Email="test3@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 4, Contact="7896541230", Email="test4@gmail.com", IsActive=false, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=2},

                new User{UserId = 101, Contact="7896541230", Email="testClient@gmail.com", IsActive=true, IsApproved=0, IsSubscribed=false, Name="test", Password="test@1234",RoleId=3},
            };
        }
    }
}
