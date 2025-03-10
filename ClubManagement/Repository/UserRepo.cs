using DataAccess.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepo
    {
        private readonly ClubManagementContext context;

        public UserRepo()
        {
            context = new ClubManagementContext();
        }

        public List<object> GetUsers()
        {
            return context.Users
                .Include(x => x.UserClubs)
                    .ThenInclude(x => x.Club)
                .Include(x => x.Role)
                .Where(x => x.RoleId == 5 || x.RoleId == 4 || x.RoleId == 3)
                .Select(u => new
                {   FullName = u.FullName, 
                    Email = u.Email,
                    Role = u.Role,
                    StudentNumber = u.StudentNumber,
                    Username = u.Username,
                    ClubName = u.UserClubs.Select(uc => uc.Club.ClubName).FirstOrDefault(),
                    AppliedAt = u.UserClubs.Select(uc => uc.AppliedAt).FirstOrDefault(),
                    ApprovedAt = u.UserClubs.Select(uc => uc.ApprovedAt).FirstOrDefault()
                })
                .ToList<object>(); // Chuyển về List<object>
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool IsUsernameExists(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }

        public bool IsStudentNumberExists(string studentNumber)
        {
            return context.Users.Any(u => u.StudentNumber == studentNumber);
        }

        public bool IsEmailExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public void CreateDate(User user)
        {
            user.Password = HashPassword(user.Password); // Mã hóa mật khẩu
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetByUsernameandPassword(string username, string password)
        {
            var find = context.Users.FirstOrDefault(u => u.Username == username);
            if (find == null || !BCrypt.Net.BCrypt.Verify(password, find.Password))
            {
                return null;
            }
            return new User
            {
                Username = find.Username,
                Role = find.Role
            };
        }
    }
}