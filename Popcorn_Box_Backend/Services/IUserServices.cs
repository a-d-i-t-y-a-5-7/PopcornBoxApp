using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public interface IUserServices
    {
        public bool AddUser(User user);
        public string Login(string email, string password);
        public bool UpdateUser(int id, User user);
        public User GetUserById(int id);
    }
}
