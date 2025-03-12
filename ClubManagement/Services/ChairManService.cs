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
    public class ChairManService
    {
        ChairmanRepo repo;

        public ChairManService()
        {
            repo = new ChairmanRepo();
        }

        public List<UserDTO> GetUsers(int ?clubId) {
            return repo.GetUsers(clubId);
        }

        public void AddUser(User user , int? clubId) { 
            repo.AddUser(user , clubId);
        }

        public void UpdateUser(User user, int? clubId) {
            repo.UpdateUser(user , clubId);
        }

    }
}
