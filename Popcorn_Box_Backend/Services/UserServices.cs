using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Popcorn_Box_Backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Popcorn_Box_Backend.Services
{
    public class UserServices : IUserServices
    {
        private readonly PopcornBoxDbContext context;
        private readonly IConfiguration _config;

        public UserServices(PopcornBoxDbContext context, IConfiguration config)
        {
            this.context = context;
            this._config = config;
        }

        public bool AddUser(User user)
        {
            var checkuser = context.Users.FirstOrDefault(u => u.Email == user.Email && u.IsActive == user.IsActive);
            if (checkuser != null)
            {
                checkuser.IsActive = true;
                context.Entry(checkuser).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            var checkUser = from u in context.Users where u.Email == user.Email select u;
            if (checkUser.Count() > 0)
            {
                return false;
            }
            user.IsActive = true;
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }
        public string Login(string email, string password)
        {
            User? user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.IsActive);
            if (user != null && user.RoleId != 3)
            {
                return GenerateToken(user);
            }
            else if (user != null && (user.RoleId == 3 && user.IsApproved == 1))
            {
                return GenerateToken(user);
            }
            else if (user != null && (user.RoleId == 3 && user.IsApproved == 0))
            {
                return "Please try after sometime your Account is not approved yet";
            }
            else return "User not found";
        }
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(type: "Id", user.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Name));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            if (user.RoleId == 1)
            {
                claims.Add(new Claim(type: "Role", "Admin"));
            }
            if (user.RoleId == 2)
            {
                claims.Add(new Claim(type: "Role", "User"));
            }
            if (user.RoleId == 3)
            {
                claims.Add(new Claim(type: "Role", "Client"));
            }
            claims.Add(new Claim(type: "IsActive", value: user.IsActive.ToString()));
            claims.Add(new Claim(type: "IsSubscribed", value: user.IsSubscribed.ToString()));
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: Credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public bool UpdateUser(int id, User user)
        {
            if (id == user.UserId)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public User GetUserById(int id)
        {
            User user = context.Users.Find(id);
            return user;
        }
    }
}
