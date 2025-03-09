using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Services
{
    public class LoginService
    {
        UserRepo repo;
        public LoginService()
        {
            repo = new UserRepo();
        }

        public User Login(string username,string password)
        {
            if (username == null || password == null)
            {
                return null;
            }
            User user = repo.GetByUsernameandPassword(username, password);
            return user;
        }
    
 
    }
}