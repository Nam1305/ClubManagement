// Trong Services/LoginService.cs
using DataAccess.Models;
using Repository;

namespace Services
{
    public class LoginService
    {
        private readonly UserRepo repo;

        public LoginService()
        {
            repo = new UserRepo();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            var user = repo.GetByUsernameandPassword(username, password);
            if (user != null && user.UserClubs.Any())
            {
                int clubId = user.UserClubs.First().ClubId; // Lấy ClubId đầu tiên từ UserClubs
                user.UserClubs = new List<UserClub> { new UserClub { ClubId = clubId } }; // Cập nhật danh sách UserClubs
            }

            return user;

        }
    }
}