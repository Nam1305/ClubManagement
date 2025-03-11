// Trong Services/RegisterService.cs
using DataAccess.Models;
using Repository;
using System;

namespace Services
{
    public class RegisterService
    {
        private readonly UserRepo userRepo;

        public RegisterService()
        {
            userRepo = new UserRepo();
        }

        public bool RegisterUser(string fullName, string email, string studentNumber, string username, string password, string roleName)
        {
            try
            {
                // Kiểm tra xem username, email, studentNumber đã tồn tại chưa
                if (userRepo.IsUsernameExists(username))
                {
                    throw new Exception("Username đã tồn tại!");
                }
                if (userRepo.IsEmailExists(email))
                {
                    throw new Exception("Email đã tồn tại!");
                }
                if (userRepo.IsStudentNumberExists(studentNumber))
                {
                    throw new Exception("Student number đã tồn tại!");
                }

                // Lấy RoleId từ bảng Roles dựa trên roleName
                var role = userRepo.GetRoleByName(roleName); // Thêm phương thức này vào UserRepo
                if (role == null)
                {
                    throw new Exception("Vai trò không hợp lệ!");
                }

                // Tạo đối tượng User mới
                User newUser = new User
                {
                    FullName = fullName,
                    Email = email,
                    StudentNumber = studentNumber,
                    Username = username,
                    Password = password, // Sẽ được mã hóa trong UserRepo.CreateDate
                    RoleId = role.RoleId, // Gán RoleId thay vì Role trực tiếp
                    Status = "active" // Mặc định là active
                };

                // Lưu vào DB
                userRepo.CreateDate(newUser);
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (có thể log hoặc hiển thị thông báo)
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}