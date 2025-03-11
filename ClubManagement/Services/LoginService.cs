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
            return repo.GetByUsernameandPassword(username, password);
        }
    }
}