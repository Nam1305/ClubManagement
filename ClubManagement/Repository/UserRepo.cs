using DataAccess.Models;
using Repository.DTO;

namespace Repository
{
    public class UserRepo
    {
        ClubManagementContext context;
        public UserRepo()
        {
            context = new ClubManagementContext();
        }
        public List<User> ReadDate()
        {
            return context.Users.ToList();
        }
        public void CreateDate(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public UserDTO GetByUsernameandPassword(string username, string password)
        {
            var find = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (find == null)
            {
                return null;
            }
            return new UserDTO
            {
                Username = find.Username,
                Role = find.Role
            };
        }
    }
}
