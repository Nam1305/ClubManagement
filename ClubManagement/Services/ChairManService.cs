using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Repository;

namespace Services
{
    public class ChairManService
    {
        UserRepo repo;

        public ChairManService()
        {
            repo = new UserRepo();
        }

        public List<User> GetUsers() {
            return repo.GetAllUsers();
        }

        public List<string> GetAllRoles()
        {
            return repo.GetAllRoles();
        }
    }
}
