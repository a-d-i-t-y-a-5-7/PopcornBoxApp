using Microsoft.EntityFrameworkCore;
using Popcorn_Box_Backend.Models;

namespace Popcorn_Box_Backend.Services
{
    public class AdminService: IAdminService
    {
        private readonly PopcornBoxDbContext _context;
        public AdminService(PopcornBoxDbContext context)
        {
            _context = context;
        }

        public List<User> GetUserDetails(int id)
        {
            var user = from u in _context.Users where u.IsActive && u.RoleId == id select u;
            return user.ToList<User>();
        }

        public bool DeleteUser(int id)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                (from u in _context.Users where u.UserId == id select user).ToList()
                    .ForEach(x => x.IsActive = false);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ApproveClient(int id)
        {
            User? user = _context.Users.Find(id);
            if (user != null && user.RoleId==3)
            {
                (from u in _context.Users where u.UserId == id && u.RoleId == 3 select user).ToList().ForEach(x => x.IsApproved = 1);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> PendingApprovals()
        {
            var pendingApp = from u in _context.Users where u.RoleId == 3 && u.IsApproved == 0 select u;
            return pendingApp.ToList<User>();
        }

    }
}

