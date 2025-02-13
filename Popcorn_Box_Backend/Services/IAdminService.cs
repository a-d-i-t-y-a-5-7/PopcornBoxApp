using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public interface IAdminService
    {
        public List<User> GetUserDetails(int id);
        public bool DeleteUser(int id);
        public bool ApproveClient(int id);
        public List<User> PendingApprovals();
    }
}
