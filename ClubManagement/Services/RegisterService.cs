using DataAccess.Models;
using Repository;
using System.Text.RegularExpressions;

namespace Services
{
    public class RegisterService
    {
        private readonly UserRepo userRepo;

        public RegisterService()
        {
            userRepo = new UserRepo();
        }

        public (bool Success, string Message) RegisterUser(string fullName, string email, string studentNumber, string username, string password)
        {
            // Kiểm tra mật khẩu: ít nhất 8 ký tự, có ít nhất 1 số và 1 chữ
            if (!IsValidPassword(password))
            {
                return (false, "Mật khẩu phải có ít nhất 8 ký tự, gồm ít nhất 1 số và 1 chữ!");
            }

            // Kiểm tra tính độc nhất
            if (userRepo.IsUsernameExists(username))
            {
                return (false, "Username đã tồn tại!");
            }

            if (userRepo.IsStudentNumberExists(studentNumber))
            {
                return (false, "Mã sinh viên đã tồn tại!");
            }

            if (userRepo.IsEmailExists(email))
            {
                return (false, "Email đã tồn tại!");
            }

            // Tạo đối tượng User mới
            User newUser = new User
            {
                FullName = fullName,
                Email = email,
                StudentNumber = studentNumber,
                Username = username,
                Password = password, // Sẽ được mã hóa trong UserRepo
                Role = "Member" // Mặc định là Member
            };

            // Lưu vào database
            userRepo.CreateDate(newUser);
            return (true, "Đăng ký thành công!");
        }

        // Hàm kiểm tra mật khẩu
        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false;
            if (!Regex.IsMatch(password, @"[0-9]")) return false; // ít nhất 1 số
            if (!Regex.IsMatch(password, @"[a-zA-Z]")) return false; // ít nhất 1 chữ
            return true;
        }

        // Các hàm kiểm tra để UI gọi nếu cần
        public bool IsUsernameExists(string username)
        {
            return userRepo.IsUsernameExists(username);
        }

        public bool IsStudentNumberExists(string studentNumber)
        {
            return userRepo.IsStudentNumberExists(studentNumber);
        }

        public bool IsEmailExists(string email)
        {
            return userRepo.IsEmailExists(email);
        }
    }
}