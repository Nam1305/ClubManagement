using DataAccess.Models;
using Repository;

namespace Services
{
    public class LoginService
    {
        private readonly UserRepo _repo;

        public LoginService()
        {
            _repo = new UserRepo();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var user = _repo.GetByUsernameAndPassword(username, password); // Sửa typo
            if (user == null)
            {
                return null;
            }

            // Cập nhật CurrentUser sau khi đăng nhập thành công
            CurrentUser.SetUser(user);

            return user;
        }
    }
}