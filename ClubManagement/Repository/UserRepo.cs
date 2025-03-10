using DataAccess.Models;
using BCrypt.Net;

namespace Repository
{
    public class UserRepo
    {
        private readonly ClubManagementContext context;

        public UserRepo()
        {
            context = new ClubManagementContext();
        }
        
        public List<User> GetAllUsers()
        {
            return context.Users.Where(x => x.Role == "vicechairman" || x.Role == "member").ToList();
        }

        public List<string> GetAllRoles()
        {
            return context.Users.Select(x => x.Role).Distinct().ToList();
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