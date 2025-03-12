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
                .Include(u => u.Role).Include(u => u.UserClubs)
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
                Status = find.Status,
                UserClubs = find.UserClubs.ToList() // Trả về danh sách UserClubs
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



        //Code cua Pham Hoang Nam
        public List<User> GetAllUsers()
        {
            return context.Users
                .Include(x => x.Role)
                .ToList();
        }

        public List<User> SearchByStudentNumber(string studentNumber)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.StudentNumber == studentNumber).ToList();
        }

        public List<User> SearchByFullName(string fullName)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.FullName == fullName).ToList();
        }

        public List<User> SearchByEmail(string email)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.Email == email).ToList();
        }

        public List<User> SearchByUserName(string userName)
        {
            return context.Users
                .Include(x => x.Role)
                .Where(u => u.Username == userName).ToList();
        }

        public bool AddNewUser(User user)
        {
            try
            {
                context.Users.Add(user);
                return context.SaveChanges() > 0; // Trả về true nếu có ít nhất 1 bản ghi được thêm
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var existingUser = context.Users.FirstOrDefault(u => u.StudentNumber == user.StudentNumber);
                if (existingUser == null)
                {
                    return false; // Không tìm thấy user để cập nhật
                }
                existingUser.FullName = user.FullName;
                //existingUser.Email = user.Email;
                existingUser.RoleId = user.RoleId;
                existingUser.StudentNumber = user.StudentNumber;
                //existingUser.Username = user.Username;
                existingUser.Status = user.Status;

                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteUser(string studentNumber)
        {
            try
            {
                var deleteStudent = GetAllUsers().Where(stud => stud.StudentNumber == studentNumber).FirstOrDefault();
                context.Remove(deleteStudent);
                return context.SaveChanges() > 0; // Trả về true nếu có ít nhất 1 bản ghi được update
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> GetUserByCbRoleChanged(int roleId)
        {
            return context.Users.Where(u => u.RoleId == roleId).ToList();
        }








    }
}