using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;
using Repository.DTO;

namespace Services
{
    public class LoginService
    {
        UserRepo repo;
        public LoginService()
        {
            repo = new UserRepo();
        }

        public UserDTO Login(string username,string password)
        {
            if (username == null || password == null)
            {
                return null;
            }
            UserDTO user = repo.GetByUsernameandPassword(username, password);
            return user;
        }
    
 
    }
}