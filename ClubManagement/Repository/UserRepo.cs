// Trong Repository/UserRepo.cs
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
            var find = context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == username);
            if (find == null || !BCrypt.Net.BCrypt.Verify(password, find.Password))
            {
                return null;
            }
            return new User
            {
                UserId = find.UserId,
                Username = find.Username,
                FullName = find.FullName,
                Email = find.Email,
                RoleId = find.RoleId,
                Role = find.Role,
                StudentNumber = find.StudentNumber,
                Status = find.Status
            };
        }

        public User GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            if (user == null)
            {
                return null;
            }

            string tempPassword = GenerateTempPassword();
            user.Password = HashPassword(tempPassword);
            context.SaveChanges();

            return tempPassword;
        }

        private string GenerateTempPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Thêm phương thức để lấy Role dựa trên roleName
        public Role GetRoleByName(string roleName)
        {
            return context.Roles.FirstOrDefault(r => r.RoleName.ToLower() == roleName.ToLower());
        }
    }
}