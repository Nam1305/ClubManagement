using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ChairmanRepo
    {
        ClubManagementContext clubManagementContext;
        public ChairmanRepo() {
           clubManagementContext  = new ClubManagementContext();
        }

        public List<User> GetUsers(int? clubId)
        {
            return clubManagementContext.Users
                .Include(x => x.Role)
                .Include(x => x.UserClubs)
                .Where(x => x.UserClubs.Any(uc => uc.ClubId == clubId)) // Lọc User có ClubId khớp
                .ToList();
        }



    }
}
