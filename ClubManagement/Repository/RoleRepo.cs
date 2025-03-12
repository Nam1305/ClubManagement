using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace Repository
{
    public class RoleRepo
    {
        ClubManagementContext context;
        public RoleRepo()
        {
          context = new ClubManagementContext();
        }

        public List<Role> Roles()
        {
            return context.Roles.ToList();
        }

        public List<Role> RolesForChairman()
        {
            return context.Roles.Where(x => x.RoleId == 3 || x.RoleId == 4 || x.RoleId == 5).ToList();
        }
    }
}
